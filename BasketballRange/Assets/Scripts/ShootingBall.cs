using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBall : MonoBehaviour
{
    public GameObject ball;
    private GameObject baller;
    private Vector3 throwDirection = new Vector3(0, 140, 70);
    private Vector3 startPos;
    [HideInInspector]
    public Vector3 curPos;
    private Vector3 forceSpeed;

    private Slider pwrSlider;
    private bool slideRight = true;
    
    public float defaultThrowForce;
    public float throwForce;
    public Scoring curScore;

    private bool holdBall = true;
    private bool shootPress = false;
    private Transform ballPos;
    private float resetTimer = 2f;

    void Start()
    {
        startPos = ball.transform.position;
        curPos = startPos;
        curScore = GameObject.FindGameObjectWithTag("Scorer").GetComponent<Scoring>();
        pwrSlider = GameObject.FindGameObjectWithTag("powerSlider").GetComponent<Slider>();
        SpawnBall();
    }

    void Update()
    {
        MovePwrBar();
        
        if (holdBall && shootPress)
        {
            ballPos.transform.position = baller.transform.position;
            holdBall = false;
            baller.GetComponent<Rigidbody>().useGravity = true;   //reapply gravity once the player has released the ball
            baller.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * throwForce);
        }

        if (baller != null && ballPos.transform.position.y < 30 && !holdBall)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0f){
                ResetBall();
                resetTimer = 2f;
            }
        }
    }

    void SpawnBall(){
        DifficultyChange();
        baller = Instantiate(ball, curPos, ball.transform.rotation) as GameObject;
        baller.name = "Baller";
        ballPos = baller.transform;
        baller.GetComponent<Rigidbody>().useGravity = false;
        
    }

    void MovePwrBar(){
        if(!shootPress){
            if(pwrSlider.value < 1 && slideRight){
            pwrSlider.value += 0.005f;
            }
            else{
                slideRight = false;
                pwrSlider.value -= 0.005f;
                if(pwrSlider.value <= 0.001f){
                    slideRight = true;
                }
            }
        }
    }

    void ResetBall(){
        Debug.Log("Destroy");
        Destroy(baller);
        holdBall = true;
        shootPress = false;
        throwDirection = new Vector3(0, 140, 70);
        pwrSlider.value = 0f;
        slideRight = true;
        curScore.isScored = false;
        SpawnBall();
    }
    void DifficultyChange()
    {
        if (curScore.score == 1){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-80);
            defaultThrowForce = 10500f;
        }else if(curScore.score == 2){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-140);
            defaultThrowForce = 11000f;

        }else if(curScore.score == 3){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-240);
            defaultThrowForce = 12000f;

        }else if(curScore.score == 4){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-360);
            defaultThrowForce = 13000f;
        }else{
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
            defaultThrowForce = 10000f;
        }
        curScore.Positioning();
    }
    public void FinalForce()
    {
        throwForce = defaultThrowForce * pwrSlider.value;
        shootPress = true;
    }

    
}
