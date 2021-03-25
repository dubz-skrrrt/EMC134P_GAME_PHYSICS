using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip BallBounce, BallBackboard, BallSwish, Lose, Win, BG, difficultyChange, throwBall, scored;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        BallBackboard = Resources.Load<AudioClip>("bounceBackboard_sfx");
        BallBounce = Resources.Load<AudioClip>("bounce_sfx");
        BallSwish = Resources.Load<AudioClip>("netSwsih_sfx");
        Lose = Resources.Load<AudioClip>("youLose_dlg");
        Win = Resources.Load<AudioClip>("youWin_dlg");
        difficultyChange = Resources.Load<AudioClip>("difficultyIncrease_sfx");
        throwBall = Resources.Load<AudioClip>("throw_sfx");
        scored = Resources.Load<AudioClip>("pointEarned_sfx");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
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
            case "youLose_dlg":
                audioSrc.PlayOneShot(Lose);
                break;
            case "youWin_dlg":
                audioSrc.PlayOneShot(Win);
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
        }
    }
}
