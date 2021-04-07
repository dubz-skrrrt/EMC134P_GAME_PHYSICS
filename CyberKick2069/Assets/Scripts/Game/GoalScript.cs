using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject ringGoal;
    public static bool goal;
    private UIText levelChange;
    void Start(){
        ringGoal = GameObject.FindGameObjectWithTag("Ring");
        levelChange = GameObject.FindGameObjectWithTag("UI").GetComponent<UIText>();
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "soccerBall"){
            Debug.Log("level Change");
            levelChange.AddLevel();
            TimerScript.timeRemaining = 60;
            Debug.Log(UIText.level);
        }
    }
}
