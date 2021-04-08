using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject ringGoal;
    public static bool goal;
    public static bool timerReset;
    private UIText levelChange;
    void Start(){
        ringGoal = GameObject.FindGameObjectWithTag("Ring");
        levelChange = GameObject.FindGameObjectWithTag("UI").GetComponent<UIText>();
        timerReset = false;
    }
    

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "soccerBall" && TimerScript.timerIsRunning){
            SoundManager.PlaySound("GoalSfx");
            levelChange.AddLevel();
            TimerScript.timerIsRunning = false;
            goal = true;
        }
    }

}
