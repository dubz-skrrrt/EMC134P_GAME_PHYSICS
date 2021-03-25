using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip BallBounce, BallBackboard, BallSwish,  BG, difficultyChange, throwBall, scored,  Click;
    public static AudioSource audioSrc;

    
    void Start()
    {
        BallBackboard = Resources.Load<AudioClip>("bounceBackboard_sfx");
        BallBounce = Resources.Load<AudioClip>("bounce_sfx");
        BallSwish = Resources.Load<AudioClip>("netSwsih_sfx");
        Click = Resources.Load<AudioClip>("buttonClick_sfx");
        difficultyChange = Resources.Load<AudioClip>("difficultyIncrease_sfx");
        throwBall = Resources.Load<AudioClip>("throw_sfx");
        scored = Resources.Load<AudioClip>("pointEarned_sfx");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {

        if (audioSrc == null){
            return;
        }else{
            switch (clip)
            {
                case "bounceBackboard_sfx":
                    audioSrc.PlayOneShot(BallBackboard);
                    break;
                case "bounce_sfx":
                    audioSrc.PlayOneShot(BallBounce);
                    break;
                case "netSwsih_sfx":
                    audioSrc.PlayOneShot(BallSwish);
                    break;
                case "difficultyIncrease_sfx":
                    audioSrc.PlayOneShot(difficultyChange);
                    break;
                case "throw_sfx":
                    audioSrc.PlayOneShot(throwBall);
                    break;
                case "pointEarned_sf":
                    audioSrc.PlayOneShot(scored);
                    break;
                case "buttonClick_sfx":
                    audioSrc.PlayOneShot(Click);
                    break;
            }
        }
        
    }
}
