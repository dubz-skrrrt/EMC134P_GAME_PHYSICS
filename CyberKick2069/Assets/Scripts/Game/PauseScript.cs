using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI;
    public SceneFader fader;
    public GameObject data;
    public GameObject directionArrow;
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void PauseGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        directionArrow = GameObject.FindGameObjectWithTag("Arrow");
        pauseUI.SetActive(!pauseUI.activeSelf);
        data.SetActive(!data.activeSelf);
        directionArrow.SetActive(!data.activeSelf);
        if(Shooting.isPaused){
            Shooting.isPaused = false;
            Time.timeScale = 1;
        }
        else{
            Shooting.isPaused = true;
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
