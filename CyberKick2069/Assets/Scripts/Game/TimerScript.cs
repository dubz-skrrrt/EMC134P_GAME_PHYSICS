using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    
    public static float timeRemaining = 10;
    public static bool TimeRunOut = false;
    
    public Text timerText;

    public static bool timerIsRunning;


    void Start(){
        timerText.text = "" + timeRemaining;
        ResetTimer(20f);
        timerIsRunning = true;
        TimeRunOut = false;
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
        //Debug.Log(timeRemaining);
    }

    public static void ResetTimer(float time){
        timeRemaining = time;
        return;
    }
}
