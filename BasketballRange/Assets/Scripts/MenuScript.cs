using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private int endCondition;
    private Text headerText;
    public GameObject niceTry;
    public SceneFader SF;

    void Start(){
        headerText = GameObject.FindGameObjectWithTag("menuHeader").GetComponent<Text>();

        if(endCondition == 1){
            headerText.text = "YOU WIN!";
            SoundManager.PlaySound("youWin_dlg");
            SoundManager.PlaySound("winGame_sfx");
        }
        else{
            headerText.text = "";
            SoundManager.PlaySound("youLose_dlg");
            SoundManager.PlaySound("loseGame_sfx");
            niceTry.SetActive(!niceTry.activeSelf);
        }

    }

    public void PlayGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        SF.FadeToScene("MainGame");
    }

    public void QuitGame(){
        SoundManager.PlaySound("buttonClick_sfx");
        Application.Quit();
    }

    void OnEnable() {
        endCondition = PlayerPrefs.GetInt("endCondition");
    }
}
