using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGameScript : MonoBehaviour
{
    private int endCondition;
    public Text headerText;
    public SoundManager audioSFX;
    public AudioClip Lost, Win,LoseMusic, WinMusic;
    public AudioSource audioSrcEG;
    public GameObject niceTry;

    void Start(){

    Lost = Resources.Load<AudioClip>("youLose_dlg");
    LoseMusic = Resources.Load<AudioClip>("loseGame_sfx");
    WinMusic = Resources.Load<AudioClip>("winGame_sfx");
    Win = Resources.Load<AudioClip>("youWin_dlg");

    if (headerText == null){
        return;
    }
    if (ShootingBall.change){
        if(ShootingBall.endCondition == 1){
            headerText.text = "YOU WIN!";
            PlaySoundEG("youWin_dlg");
            PlaySoundEG("winGame_sfx");
        }
        else{
            headerText.text = "";
            PlaySoundEG("lost");
            PlaySoundEG("loseGame_sfx");
            niceTry.SetActive(!niceTry.activeSelf);
        }
    }
    
        

    }  

    public void PlaySoundEG(string clip)
    {
        switch (clip)
        {
        case "lost":
            audioSrcEG.PlayOneShot(Lost);
            break;
        case "youWin_dlg":
            audioSrcEG.PlayOneShot(Win);
            break;

        case "loseGame_sfx":
            audioSrcEG.PlayOneShot(LoseMusic);
            break;
        case "winGame_sfx":
            audioSrcEG.PlayOneShot(WinMusic);
            break;
        }
    }    
 

}
