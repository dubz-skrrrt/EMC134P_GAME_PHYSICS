using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip BallBounce;
    public static AudioSource audioSrc;

    
    void Start()
    {
       

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {

        if (audioSrc == null){
            return;
        }else{
            switch (clip)
            {
                case "bounce_sfx":
                    audioSrc.PlayOneShot(BallBounce);
                    break;
            }
        }
        
    }
}
