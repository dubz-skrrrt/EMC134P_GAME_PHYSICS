using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public ShootingBall SB;
    public GameObject pauseUI;
    public SceneFader fader;
    public GameObject menubtn;
    public GameObject data;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void PauseGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        pauseUI.SetActive(!pauseUI.activeSelf);
        menubtn.SetActive(!menubtn.activeSelf);
        data.SetActive(!data.activeSelf);
        if(SB.isPaused){
            SB.isPaused = false;
            Time.timeScale = 1;
        }
        else{
            SB.isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void Retry()
    {
        PauseGame();
        SoundManager.PlaySound("buttonClick_sfx");
        fader.FadeToScene(SceneManager.GetActiveScene().name);
        

    }

    public void Menu()
    {
        PauseGame();
        SoundManager.PlaySound("buttonClick_sfx");
        fader.FadeToScene("MainMenu");
    }
}
