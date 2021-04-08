using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsSync : MonoBehaviour
{
    public AudioSource music;
    public Animator animator;
 
    private float MusicPos; //Position of the playback head from the last beat
    [Tooltip("Interval of the trigger")]
    public float BPM = 0;
    [Tooltip("Sample Rate")]
    public float SampleRate = 96000;
 
    void Start()
    {
        // music = GameObject.Find("Music").GetComponent<AudioSource>();
        // animator = GetComponent<Animator>();
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
            Debug.Log("Beat");
            animator.SetTrigger("Beat");
            MusicPos = music.timeSamples;
        }
    }
}
