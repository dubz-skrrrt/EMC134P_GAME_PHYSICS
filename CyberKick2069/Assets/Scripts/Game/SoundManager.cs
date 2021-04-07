using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ballKick, btnClick;
    public static AudioSource audioSrc;

    
    void Start()
    {
        ballKick = Resources.Load<AudioClip>("KickSFX");
        btnClick = Resources.Load<AudioClip>("buttonClick_sfx");

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
            }
        }
        
    }
}
