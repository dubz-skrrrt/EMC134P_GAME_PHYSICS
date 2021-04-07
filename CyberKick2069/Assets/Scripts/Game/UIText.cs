using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public Text levelText;
    public int level = 1;

    // public Text numOfBallsUI;
    // public int numOfBalls = 5;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "" + level;
        //numOfBallsUI.text = "x " + numOfBalls;
    }

    public void AddLevel() // increase 1 level
    {
        level++;
        levelText.text = "" + level;
    }

    // public void DecreaseNumberOfBalls() // decrease 1 attempt
    // {
    //     numOfBalls--;
    //     numOfBallsUI.text = "x " + numOfBalls;
    // }

    // void LevelResult() 
    // {
    //     if (level > 4) // if player finishes game with balls remaining
    //     {
    //         EndScene.resultTextToString = "You WIN! You cookin' like Steph";
    //         SceneManager.LoadScene("ResultMenu");
    //     }
    //     else if ((level == 4) && (numOfBalls == 0)) // if player loses all attempts in level 4
    //     {
    //         EndScene.resultTextToString = "Almost there, you were kinda hot like Dame";
    //         SceneManager.LoadScene("ResultMenu");
    //     }
    //     else if ((level == 3) && (numOfBalls == 0)) // if player loses all attempts in level 3
    //     {
    //         EndScene.resultTextToString = "Aw come on Kobe, show me that Mamba mentality";
    //         SceneManager.LoadScene("ResultMenu");
    //     }
    //     else if ((level == 2) && (numOfBalls == 0)) // if player loses all attempts in level 2
    //     {
    //         EndScene.resultTextToString = "Uh oh, gotta do more practice like Lebron";
    //         SceneManager.LoadScene("ResultMenu");
    //     }
    //     else if ((level == 1) && (numOfBalls == 0)) // if player loses all attempts in level 1
    //     {
    //         EndScene.resultTextToString = "You shootin' bricks? Man, you like Shaq dude";
    //         SceneManager.LoadScene("ResultMenu");
    //     }
    // }

    void Update()
    {
        //LevelResult();
    }
}
