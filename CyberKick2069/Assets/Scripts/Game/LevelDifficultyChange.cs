using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelDifficultyChange : MonoBehaviour
{
    private SceneFader fader;
    private UIText levelChange;
    public Animator RingGoal;
    public Animator[] EnemyAnims;
    void Start()
    {
        fader = GameObject.FindGameObjectWithTag("SceneFader").GetComponent<SceneFader>();
        levelChange = GameObject.FindGameObjectWithTag("UI").GetComponent<UIText>();
       // RingGoal = GameObject.FindGameObjectWithTag("Ring").GetComponent<Animator>();
        //EnemyAnims = GameObject.Find("Obstacles").GetComponentsInChildren<Animator>(true);
    }

    
    void Update()
    {
        if (TimerScript.TimeRunOut){
            DecreaselevelDifficulty();
        }
        
    }
    void LateUpdate(){
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
            
        }else if (UIText.level == 2 && TimerScript.TimeRunOut){
            TimerScript.TimeRunOut = false;
            for (int i = 0; i < EnemyAnims.Length; i++)
            {
                 if (i%2 == 0){
                    EnemyAnims[i].gameObject.SetActive(false);
                }
               
            }
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            TimerScript.ResetTimer(20f);
            
        }
        else if (UIText.level == 3 && TimerScript.TimeRunOut){
            TimerScript.TimeRunOut = false;
            for (int i = 0; i < EnemyAnims.Length; i++)
            {
                 if (i%2 == 0){
                    
                }else{
                    EnemyAnims[i].gameObject.SetActive(false);
                }
               
            }
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            DirectionalArrow.isMoving = true;
            TimerScript.ResetTimer(20f);
        }
        else if (UIText.level == 4 && TimerScript.TimeRunOut){
            TimerScript.TimeRunOut = false;
            levelChange.MinusLevel();
            TimerScript.timerIsRunning = true;
            Shooting.directionFirst = false;
            DirectionalArrow.isMoving = true;
            RingGoal.SetBool("Level3", false);
            TimerScript.ResetTimer(20f);
        }
        
    }

    void IncreaseLevelDifficulty(){
        if (UIText.level == 2){
            for (int i = 0; i < EnemyAnims.Length; i++)
            {
                if (i == 0){
                    EnemyAnims[i].speed = i +1 *0.5f;
                }else{
                    EnemyAnims[i].speed = i*0.5f;
                }
                

                if (i%2 == 0){
                    EnemyAnims[i].SetInteger("Dir", 1);
                    EnemyAnims[i].gameObject.SetActive(true);
                }
                else{
                    EnemyAnims[i].SetInteger("Dir", 0);
                   
                }
                
            }
            TimerScript.ResetTimer(60f);
        }
        else if (UIText.level == 3){
            for (int i = 0; i < EnemyAnims.Length; i++)
            {
                if (i == 0){
                    EnemyAnims[i].speed = i +1 *0.5f;
                }else{
                    EnemyAnims[i].speed = i*0.5f;
                }
                

                if (i%2 == 0){
                    EnemyAnims[i].SetInteger("Dir", 1);
                    
                }
                else{
                    EnemyAnims[i].SetInteger("Dir", 0);
                    EnemyAnims[i].gameObject.SetActive(true);
                }
            }
                
        }
        else if (UIText.level == 4){
            
            RingGoal = GameObject.FindGameObjectWithTag("Ring").GetComponent<Animator>();
            RingGoal.SetBool("Level3", true);
        }
        else if (UIText.level == 5){
            Debug.Log("reset");
            
        }
        TimerScript.ResetTimer(20f);
        TimerScript.timerIsRunning = true;
    }

    IEnumerator SceneChangeDelay(){
        yield return new WaitForSeconds(5.5f);
        fader.FadeToScene(SceneManager.GetActiveScene().name);
    }
}
