using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ballKick, btnClick, timerRunOut, goalSFX, hitPost, hitFence;
    public static AudioSource audioSrc;

    
    void Start()
    {
        ballKick = Resources.Load<AudioClip>("KickSFX");
        btnClick = Resources.Load<AudioClip>("buttonClick_sfx");
        timerRunOut = Resources.Load<AudioClip>("TimerRunOut_Dlg");
        goalSFX = Resources.Load<AudioClip>("GoalSfx");
        hitPost = Resources.Load<AudioClip>("HitPost");
        hitFence = Resources.Load<AudioClip>("HitFence");
        
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
            }
        }
        
    }
}
