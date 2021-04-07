using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    public static float timeRemaining = 10;
    public static bool TimeRunOut = false;
    
    public Text timerText;

    private bool timerIsRunning;


    void Start(){
        timerText.text = "" + timeRemaining;
        timeRemaining = 10;
        timerIsRunning = true;
    }
    void Update(){
        if (timerIsRunning){
            if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            timerText.text = "" + Mathf.Round(timeRemaining);
            }
            else{
                timerIsRunning = false;
                TimeRunOut = true;
            }
        }
        
    }
}
