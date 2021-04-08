using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public Text levelText;
    public static int level = 1;
    public static bool lose;
    public GameObject shootBtn;
    public GameObject stopBtn;
    
    public Animator animation;
    public Animator[] ballAnim;
    
    public GameObject[] ballIcon;
    public static int numOfBalls = 3;


    // Start is called before the first frame update
    void Start()
    {
        // shootBtn = GameObject.FindGameObjectWithTag("ShootBtn");
        // stopBtn = GameObject.FindGameObjectWithTag("StopBtn");
        shootBtn.gameObject.SetActive(false);
        stopBtn.gameObject.SetActive(true);
        levelText.text = "LEVEL: " + level;
    }

    public void AddLevel() // increase 1 level
    {
        animation.SetTrigger("ChangeLevel");
        level++;
        levelText.text = "LEVEL: " + level;
    }

    public void MinusLevel(){ // decrease 1 level
        level--;
        levelText.text = "LEVEL: " + level;
    }

    public void DecreaseTries() // decrease 1 attempt
    {
        numOfBalls--;

        if (numOfBalls < 1)
        {
            ballAnim[0].SetTrigger("DecreaseBall1");
            StartCoroutine(DelayAnim1());
        } 
        else if (numOfBalls < 2)
        {
            ballAnim[1].SetTrigger("DecreaseBall2");
            StartCoroutine(DelayAnim2());
        }
        else if (numOfBalls < 3)
        {
            ballAnim[2].SetTrigger("DecreaseBall3");
            StartCoroutine(DelayAnim3());
        }

        Debug.Log("Tries: " + numOfBalls);
    }

    void LevelResult() 
    {
        if (level > 4) // if player finishes game with balls remaining
        {
            EndScene.resultTextToString = "You WIN! GOLAAAAZOOOO! A Hat trick like Ronaldo";
            SceneManager.LoadScene("ResultMenu");
            
        }
        else if ((level == 4) && (numOfBalls == 0)) // if player loses all attempts in level 4
        {
            EndScene.resultTextToString = "Almost there, Dribbling left and right like Messi";
            lose = true;
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 3) && (numOfBalls == 0)) // if player loses all attempts in level 3
        {
            EndScene.resultTextToString = "Just like what Maradonna said, 'When people succeed, it's because of hard work. Luck has nothing to do with success', so TRY HARDER!";
            lose = true;
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 2) && (numOfBalls == 0)) // if player loses all attempts in level 2
        {
            EndScene.resultTextToString = "Everything is practice, and practice gets you closer to perfection just like Pele";
            lose = true;
            SceneManager.LoadScene("ResultMenu");
        }
        else if ((level == 1) && (numOfBalls == 0)) // if player loses all attempts in level 1
        {
            EndScene.resultTextToString = "'Man you givin up?', Giving up is not found in the dictionary of Ibrahimovic";
            lose = true;
            SceneManager.LoadScene("ResultMenu");
        }
    }

    IEnumerator DelayAnim1()
    {
        yield return new WaitForSeconds(1f);
        Destroy(ballIcon[0].gameObject);
    }

    IEnumerator DelayAnim2()
    {
        yield return new WaitForSeconds(1f);
        Destroy(ballIcon[1].gameObject);
    }

    IEnumerator DelayAnim3()
    {
        yield return new WaitForSeconds(1f);
        Destroy(ballIcon[2].gameObject);
    }

    void Update()
    {
        LevelResult();
        if (Shooting.directionFirst){
            shootBtn.gameObject.SetActive(true);
            stopBtn.gameObject.SetActive(false);
        }else{
            shootBtn.gameObject.SetActive(false);
            stopBtn.gameObject.SetActive(true);
        }
    }
}
