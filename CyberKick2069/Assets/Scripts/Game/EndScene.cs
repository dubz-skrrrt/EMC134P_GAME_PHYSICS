using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public static string resultTextToString;
    public Text ResultText;

    public SoundManager audioSFX;
    public SceneFader SF;

    void Start()
    {
        ResultText.text = resultTextToString;
        UIText.numOfBalls = 3;
        UIText.level = 1;
    }

    public void PlayGame()
    {
        SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene("PlayGame");
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("buttonClick_sfx");
        Application.Quit();
    }
}
