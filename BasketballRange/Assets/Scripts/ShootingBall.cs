using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingBall : MonoBehaviour
{
    public GameObject ball;
    private GameObject baller;
    private Vector3 throwDirection = new Vector3(0, 140, 70);
    private Vector3 startPos;
    [HideInInspector]
    public Vector3 curPos;
    private bool isWinner;
    [HideInInspector]
    public bool isPaused = false;

    private Slider pwrSlider;
    private bool slideRight = true;
    
    public float defaultThrowForce;
    public float throwForce;
    public Scoring curScore;
    public ScoreChecker SC;

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

    void FixedUpdate() //Physics Updates
    {
        if (holdBall && shootPress && !isPaused)
        {
            ballPos.transform.position = baller.transform.position;
            holdBall = false;
            baller.GetComponent<Rigidbody>().useGravity = true;   //reapply gravity once the player has released the ball
            baller.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * throwForce);
        }
    }

    void Update(){ //General Updates
        MovePwrBar();

        if (baller != null && ballPos.transform.position.y < 35 && !holdBall){
            resetTimer -= Time.deltaTime;
            
            if(resetTimer <= 0f){
                
                ResetBall();
                resetTimer = 1f;
            }
        }
    }

    void SpawnBall(){
        CheckAttempts();
        DifficultyChange();
        baller = Instantiate(ball, curPos, ball.transform.rotation) as GameObject;
        baller.name = "Baller";
        ballPos = baller.transform;
        baller.GetComponent<Rigidbody>().useGravity = false;
        
    }

    void MovePwrBar(){
        if(!shootPress && !isPaused){
            if(pwrSlider.value < 1 && slideRight){
            pwrSlider.value += 0.001f;
            }
            else{
                slideRight = false;
                pwrSlider.value -= 0.001f;
                if(pwrSlider.value <= 0){
                    slideRight = true;
                }
            }
        }
    }

    void CheckAttempts(){
        if(!curScore.isScored){
            if(curScore.lives > 0){
                if(curScore.score == 5){
                    isWinner = true;
                    SceneManager.LoadScene("EndMenu");
                }
            }
            else{
                isWinner = false;
                SceneManager.LoadScene("EndMenu");
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
        SC.underBasket = false;
        SpawnBall();
    }

    void DifficultyChange()
    {
        if (curScore.score == 1){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-80);
            defaultThrowForce = 16500f;
        }else if(curScore.score == 2){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-140);
            defaultThrowForce = 17500f;

        }else if(curScore.score == 3){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-240);
            defaultThrowForce = 18500f;

        }else if(curScore.score == 4){
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z-360);
            defaultThrowForce = 20000f;
        }else{
            curPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
            defaultThrowForce = 15000f;
        }
        curScore.Positioning();
    }

    void OnDisable()
    {
        if(isWinner){
            PlayerPrefs.SetInt("endCondition", 1);
        }
        else{
            PlayerPrefs.SetInt("endCondition", 0);
        }
    }


    public void FinalForce()
    {
        if(!isPaused){
            throwForce = defaultThrowForce * pwrSlider.value;
            shootPress = true;
        }
    }

    
}
