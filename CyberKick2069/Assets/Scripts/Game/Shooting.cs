using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody rb;
    float fFactor = 100;
    Vector3 magnusForce;
    //static variables
    public static bool shoot;
    public static bool shootStart;
    public static bool directionFirst;
    public static bool forceSecond;
    public static Vector3 offset = new Vector3(0,0.2f, 0.5f);

    [Header("References")]
    public Animation cameraAnim;
    
    public ParticleSystem hitFX;
    //Private var
    private bool isGrounded;
    private GameObject cam;
    
    private Vector3 startCamPos;
    private Spawner spawnScript;
    private UIText textScript;

    [Header("Shooting Attributes")]
    public float defaultShootingForce;
    private float finalForce;

    void Start() {
        //spawnScript.SpawnBall();
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        textScript = GameObject.FindGameObjectWithTag("UI").GetComponent<UIText>();
        rb = GameObject.FindGameObjectWithTag("soccerBall").GetComponent<Rigidbody>();
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        hitFX = GameObject.FindGameObjectWithTag("BallFX").GetComponent<ParticleSystem>();
        startCamPos = cam.transform.position;
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
            cameraAnim.Play("CameraZoomOutShoot");
            forceSecond = true;
            shootStart = true;
        }
       
    }
    void FixedUpdate()
    {
        magnusForce = fFactor * Vector3.Cross(rb.velocity, rb.angularVelocity);
        Debug.Log(magnusForce);
        kickBall();
    }

    void RespawnBall(){
        
        if (isGrounded){
            Destroy(spawnScript.soccerBallClone);
            spawnScript.soccerBallClone.SetActive(false);
            Destroy(spawnScript.spawnedArrow);
            //Resets attributes
            cam.transform.position = startCamPos;
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
            else 
            {
                textScript.DecreaseTries();
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
                rb.AddForce(magnusForce * finalForce, ForceMode.VelocityChange);
                rb.AddForce(new Vector3(spawnScript.spawnedArrow.transform.forward.x, spawnScript.spawnedArrow.transform.up.y / 2, spawnScript.spawnedArrow.transform.forward.z) * finalForce, ForceMode.VelocityChange);
                
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
        hitFX.Play();
        if (col.gameObject.tag == "Ground" && shoot == true){
            StartCoroutine(ResetDelay());
        }
    }


    IEnumerator ResetDelay(){
        yield return new WaitForSeconds(2f);
        isGrounded = true;
    }
}