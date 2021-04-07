using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody rb;
    float fFactor = 1000;
    Vector3 magnusForce;
    public static bool shoot;
    public static Vector3 offset = new Vector3(-0.1f,0, 0.5f);
    private Spawner spawnScript;

    [Header("Shooting Attributes")]
    public float defaultShootingForce;
    private float finalForce;


    void Start() {
        //spawnScript.SpawnBall();
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        rb = GameObject.FindGameObjectWithTag("soccerBall").GetComponent<Rigidbody>();
        shoot = false;
    }

    void Update()
    {
        spawnScript.spawnedArrow.transform.position = rb.transform.position +offset;

        if (spawnScript.soccerBallClone.transform.position.y < 0){
            Destroy(spawnScript.soccerBallClone);
            spawnScript.soccerBallClone.SetActive(false);
            Destroy(spawnScript.spawnedArrow);
            spawnScript.SpawnBall();
            spawnScript.DirectionalArrow();
            spawnScript.soccerBallClone.SetActive(true);
            spawnScript.spawnedArrow.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        magnusForce = fFactor * Vector3.Cross(rb.velocity, rb.angularVelocity);
        if (Input.GetKeyDown(KeyCode.Space)){
            shoot = true;
            finalShootingForce();
            rb.AddTorque (Vector3.forward, ForceMode.Force);
            rb.AddForce(new Vector3(spawnScript.spawnedArrow.transform.forward.x, spawnScript.spawnedArrow.transform.up.y / 2, spawnScript.spawnedArrow.transform.forward.z) * finalForce, ForceMode.VelocityChange);
            rb.AddForce(magnusForce, ForceMode.VelocityChange);
            spawnScript.spawnedArrow.SetActive(false);
            
        }
    }


    public void finalShootingForce(){
        if (shoot){
            finalForce = defaultShootingForce * ShootingForce.powSlider.value;
            shoot = false;
        }
    }
}