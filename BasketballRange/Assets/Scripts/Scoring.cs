using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText, livesText;
    private Vector3 offset = new Vector3(0, 40, 20);
    private Vector3 camOffset = new Vector3(0, -70, 140);
    private ShootingBall gameManager;

    public GameObject UI;
    public GameObject mainCamera;
    [HideInInspector]
    public ShootingBall shooting;
    [HideInInspector]
    public bool isScored = false;
    [HideInInspector]
    public int score, lives;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<ShootingBall>();

        score = 0;
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score;

        lives = 3;
        livesText = GameObject.FindGameObjectWithTag("livesTxt").GetComponent<Text>();
        livesText.text = lives.ToString();

        Positioning();
    }


    void OnTriggerExit(Collider other) {
       
        if(other.gameObject.name == "Baller" && isScored == false && shooting.SC.underBasket == false){
            Debug.Log("score!");
            score++;
            isScored = true;
            scoreText.text = "Score: " + score;
        }
    }



    public void Positioning()
    {
        UI.transform.position = shooting.curPos + offset;
        mainCamera.transform.position = shooting.curPos - camOffset;
    }
}
