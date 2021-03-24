using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private int endCondition;
    private Text headerText;
    public SceneFader SF;

    void Start(){
        headerText = GameObject.FindGameObjectWithTag("menuHeader").GetComponent<Text>();

        if(endCondition == 1){
            headerText.text = "YOU WIN!";
        }
        else{
            headerText.text = "GAME OVER!";
        }

    }

    public void PlayGame(){
        SF.FadeToScene("MainGame");
    }

    public void QuitGame(){
        Application.Quit();
    }

    void OnEnable() {
        endCondition = PlayerPrefs.GetInt("endCondition");
    }
}
