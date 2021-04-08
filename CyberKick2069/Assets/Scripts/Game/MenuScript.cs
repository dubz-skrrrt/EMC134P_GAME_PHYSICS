using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public SoundManager audioSFX;
    public SceneFader SF;
    private string LevelToLoad = "PlayGame";

    void Start(){

    }

    public void PlayGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene(LevelToLoad);
    }

    public void QuitGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        Application.Quit();
    }
}
