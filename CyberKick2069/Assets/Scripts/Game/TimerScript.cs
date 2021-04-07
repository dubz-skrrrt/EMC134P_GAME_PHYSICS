using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    [SerializeField]
    public static float timeRemaining = 60;
    public static bool TimeRunOut = false;
    
    public Text timerText;

    private bool timerIsRunning;


    void Start(){
        timerText.text = "" + timeRemaining;
        timeRemaining = 60;
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
