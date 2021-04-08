using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody rb;
    float fFactor = 1000;
    Vector3 magnusForce;
    public static bool shoot;
    public static bool shootStart;
    public static bool directionFirst;
    public static bool forceSecond;
    private bool isGrounded;
    public static Vector3 offset = new Vector3(-0.1f,0.2f, 0.5f);
    private Spawner spawnScript;

    [Header("Shooting Attributes")]
    public float defaultShootingForce;
    private float finalForce;

    void Start() {
        //spawnScript.SpawnBall();
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        rb = GameObject.FindGameObjectWithTag("soccerBall").GetComponent<Rigidbody>();
        shoot = false;
        shootStart = false;
        directionFirst = false;
        forceSecond = false;
    }

    void Update()
    {
        spawnScript.spawnedArrow.transform.position = rb.transform.position +offset;
        RespawnBall();

        if (Input.GetKeyDown(KeyCode.R) && TimerScript.timerIsRunning && directionFirst){
            ShootingForce.powSlider.value = 0;
            directionFirst = false;;
        }
        if (Input.GetKeyDown(KeyCode.Space) && TimerScript.timerIsRunning){
            directionFirst = true;
        }
        if(Input.GetKeyDown(KeyCode.F) && !shootStart && directionFirst && TimerScript.timerIsRunning){
            forceSecond = true;
            shootStart = true;
        }
       
    }
    void FixedUpdate()
    {
        magnusForce = fFactor * Vector3.Cross(rb.velocity, rb.angularVelocity);
        kickBall();
    }

    void RespawnBall(){
        
        if (isGrounded){
            Destroy(spawnScript.soccerBallClone);
            spawnScript.soccerBallClone.SetActive(false);
            Destroy(spawnScript.spawnedArrow);
            //Resets attributes
            
            shoot = false;
            isGrounded = false;
            AnimScript.kickAnim = false;
            spawnScript.Player.transform.position = spawnScript.startPlayerPos;
            spawnScript.Player.transform.rotation = spawnScript.startPlayerRot;

            //Calls Spawner
            if (GoalScript.goal){
                Debug.Log("Reset true");
                GoalScript.timerReset = true;
                TimerScript.TimeRunOut = false;
            }
            spawnScript.SpawnBall();
            spawnScript.DirectionalArrow();
            //Active prefabs
            spawnScript.soccerBallClone.SetActive(true);
            spawnScript.spawnedArrow.SetActive(true);
        }
    }

    void kickBall(){
        if (!shoot && AnimScript.kickAnim){
                shoot = true;
                finalShootingForce();
                rb.AddTorque (Vector3.forward, ForceMode.Force);
                rb.AddForce(new Vector3(spawnScript.spawnedArrow.transform.forward.x, spawnScript.spawnedArrow.transform.up.y / 2, spawnScript.spawnedArrow.transform.forward.z) * finalForce, ForceMode.VelocityChange);
                rb.AddForce(magnusForce, ForceMode.VelocityChange);
                SoundManager.PlaySound("KickSFX");
                spawnScript.spawnedArrow.SetActive(false);
            }
    }
    public void finalShootingForce(){
        if (shoot){
            finalForce = defaultShootingForce * ShootingForce.powSlider.value;
            shootStart = false;
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Ground" && shoot == true){
            StartCoroutine(ResetDelay());
        }
    }

    IEnumerator ResetDelay(){
        yield return new WaitForSeconds(2f);
        isGrounded = true;
    }
}