using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public static string resultTextToString;
    public Text ResultText;

    public bool playOnce;
    public SoundManager audioSFX;
    public SceneFader SF;


    void Start()
    {
        ResultText.text = resultTextToString;
        playOnce = false;
    }

    void LevelToAudio()
    {
        if (UIText.level > 4) 
        {
            SoundManager.PlaySound("Line5_Dlg");
        }
        else if (UIText.level == 4) 
        {
            SoundManager.PlaySound("Line4_Dlg");
        }
        else if (UIText.level == 3) 
        {
            SoundManager.PlaySound("Line3_Dlg");
        }
        else if (UIText.level == 2) 
        {
            SoundManager.PlaySound("Line2_Dlg");
        }
        else if (UIText.level == 1) 
        {
            SoundManager.PlaySound("Line1_Dlg");
        }
    }

    void Update()
    {
        if(!playOnce){
            LevelToAudio();
            playOnce = true;
        }
            

    }

    public void PlayGame()
    {
        SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene("PlayGame");
        UIText.numOfBalls = 3;
        UIText.level = 1;
    }

    public void Menu()
    {
        SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene("MainMenu");
    }
}
