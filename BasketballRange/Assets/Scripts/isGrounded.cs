using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public Scoring score;
    public bool grounded = false;

    void OnCollisionEnter(Collision col){
        if (col.gameObject.name == "Baller" && !score.isScored){
            SoundManager.PlaySound("bounce_sfx");
            score.lives--;
            score.livesText.text = score.lives.ToString();
            score.isScored = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        SoundManager.PlaySound("bounce_sfx");
    }
}
