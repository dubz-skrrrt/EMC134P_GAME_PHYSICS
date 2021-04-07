using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public SoundManager audioSFX;
    public SceneFader SF;

    void Start(){

    }

    public void PlayGame(){
        //SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene("PlayGame");
    }

    public void QuitGame(){
        //SoundManager.PlaySound("buttonClick_sfx");
        Application.Quit();
    }
}
