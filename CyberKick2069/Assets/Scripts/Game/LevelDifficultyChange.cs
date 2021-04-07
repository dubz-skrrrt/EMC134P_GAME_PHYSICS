using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelDifficultyChange : MonoBehaviour
{
    private SceneFader fader;
    private UIText levelChange;
    void Start()
    {
         fader = GameObject.FindGameObjectWithTag("SceneFader").GetComponent<SceneFader>();
         levelChange = GameObject.FindGameObjectWithTag("UI").GetComponent<UIText>();
    }

    
    void Update()
    {
        if (TimerScript.TimeRunOut){
            DecreaselevelDifficulty();
        }
        if (GoalScript.goal && GoalScript.timerReset){
            Debug.Log("Check");
            GoalScript.goal = false;
            GoalScript.timerReset = false;
            IncreaseLevelDifficulty();
        }
    }

    void DecreaselevelDifficulty(){
        if (UIText.level == 1 && TimerScript.TimeRunOut){
            SoundManager.PlaySound("Timer_Dlg");
            UIText.level = 1;
            Debug.Log("RunOutofTime");
            TimerScript.TimeRunOut = false;
            StartCoroutine(SceneChangeDelay());
            
        }else if (UIText.level == 2 && TimerScript.TimeRunOut && !GoalScript.goal){
            TimerScript.TimeRunOut = false;
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            TimerScript.ResetTimer(10f);
            
        }
        else if (UIText.level == 3 && TimerScript.TimeRunOut){
            TimerScript.TimeRunOut = false;
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            TimerScript.ResetTimer(10f);
        }
        else if (UIText.level == 4 && TimerScript.TimeRunOut){
            TimerScript.TimeRunOut = false;
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            TimerScript.ResetTimer(10f);
        }
        
    }

    void IncreaseLevelDifficulty(){
        if (UIText.level == 2){
            Debug.Log("reset");
            
            TimerScript.ResetTimer(10f);
        }
        else if (UIText.level == 3){
            Debug.Log("reset");
            TimerScript.ResetTimer(10f);
        }
        else if (UIText.level == 4){
            Debug.Log("reset");
            TimerScript.ResetTimer(10f);
        }
        else if (UIText.level == 5){
            Debug.Log("reset");
            TimerScript.ResetTimer(10f);
        }
        TimerScript.timerIsRunning = true;
    }

    IEnumerator SceneChangeDelay(){
        yield return new WaitForSeconds(5.5f);
        fader.FadeToScene(SceneManager.GetActiveScene().name);
    }
}
