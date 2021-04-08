using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ballKick, btnClick, timerRunOut, goalSFX, hitPost, hitFence, winResult1, winResult2, winResult3, winResult4, winResult5;
    public static AudioSource audioSrc;

    
    void Start()
    {
        ballKick = Resources.Load<AudioClip>("KickSFX");
        btnClick = Resources.Load<AudioClip>("buttonClick_sfx");
        timerRunOut = Resources.Load<AudioClip>("TimerRunOut_Dlg");
        goalSFX = Resources.Load<AudioClip>("GoalSfx");
        hitPost = Resources.Load<AudioClip>("HitPost");
        hitFence = Resources.Load<AudioClip>("HitFence");

        winResult1 = Resources.Load<AudioClip>("Line1_Dlg");
        winResult2 = Resources.Load<AudioClip>("Line2_Dlg");
        winResult3 = Resources.Load<AudioClip>("Line3_Dlg");
        winResult4 = Resources.Load<AudioClip>("Line4_Dlg");
        winResult5 = Resources.Load<AudioClip>("Line5_Dlg");
        
        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {

        if (audioSrc == null){
            return;
        }else{
            switch (clip)
            {
                case "KickSFX":
                    audioSrc.PlayOneShot(ballKick);
                    break;
                case "buttonClick_sfx":
                    audioSrc.PlayOneShot(btnClick);
                    break;
                case "Timer_Dlg":
                    audioSrc.PlayOneShot(timerRunOut);
                    break;
                case "GoalSfx":
                    audioSrc.PlayOneShot(goalSFX);
                    break;
                case "HitPost":
                    audioSrc.PlayOneShot(hitPost);
                    break;
                case "HitFence":
                    audioSrc.PlayOneShot(hitFence);
                    break;
                case "Line1_Dlg":
                    audioSrc.PlayOneShot(winResult1);
                    break;
                case "Line2_Dlg":
                    audioSrc.PlayOneShot(winResult2);
                    break;
                case "Line3_Dlg":
                    audioSrc.PlayOneShot(winResult3);
                    break;
                case "Line4_Dlg":
                    audioSrc.PlayOneShot(winResult4);
                    break;
                case "Line5_Dlg":
                    audioSrc.PlayOneShot(winResult5);
                    break;
            }
        }
        
    }
}
