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
    private Spawner spawn;

    void Start(){
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }
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
        data.SetActive(!data.activeSelf);
        
        if(Shooting.isPaused){
            DirectionalArrow.isMoving = true;
            Shooting.isPaused = false;
            Time.timeScale = 1;
        }
        else{
            DirectionalArrow.isMoving = false;
            Shooting.isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void Retry()
    {
        PauseGame();
        SoundManager.PlaySound("buttonClick_sfx");
        fader.FadeToScene(SceneManager.GetActiveScene().name);
        Shooting.isGrounded = true;
        Destroy(spawn.Player);

    }

    public void Menu()
    {
        PauseGame();
        SoundManager.PlaySound("buttonClick_sfx");
        fader.FadeToScene("MainMenu");
        Shooting.isGrounded = true;
        Destroy(spawn.Player);
    }
    
}
