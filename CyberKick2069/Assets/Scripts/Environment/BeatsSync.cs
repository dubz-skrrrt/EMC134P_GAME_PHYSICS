using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsSync : MonoBehaviour
{
    public AudioSource music;
    public Animator animator;

    //private Quaternion targetRot;
 
    private float MusicPos; //Position of the playback head from the last beat
    [Tooltip("Interval of the trigger")]
    public float BPM = 0;
    [Tooltip("Sample Rate")]
    public float SampleRate = 44100;
 
    void Start()
    {
        StartMusic();
    }
 
    void StartMusic()
    {
        MusicPos = 0;
        music.Play();
    }
 
    void Update()
    {
        
        if (music.timeSamples - MusicPos > SampleRate * (60 / BPM))
        {
            animator.SetTrigger("Beat");
            // targetRot = Quaternion.Euler(0, 0, Random.Range(-10, 10));
            // transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, Time.deltaTime * MusicPos);
            MusicPos = music.timeSamples;
        }
    }
}
