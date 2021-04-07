using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelDifficultyChange : MonoBehaviour
{
    private SceneFader fader;
    void Start()
    {
         fader = GameObject.FindGameObjectWithTag("SceneFader").GetComponent<SceneFader>();
    }

    
    void Update()
    {
        if (TimerScript.TimeRunOut){
            ChangelevelDifficulty();
        }
    }

    void ChangelevelDifficulty(){
        if (UIText.level == 1 && TimerScript.TimeRunOut){
            SoundManager.PlaySound("Timer_Dlg");
            Debug.Log("RunOutofTime");
            TimerScript.TimeRunOut = false;
            StartCoroutine(SceneChangeDelay());
            
        }
    }

    IEnumerator SceneChangeDelay(){
        yield return new WaitForSeconds(5.5f);
        fader.FadeToScene(SceneManager.GetActiveScene().name);
    }
}
