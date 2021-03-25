using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{

    public Scoring score;
    public bool grounded = false;

    void OnTriggerEnter(Collider col){
        SoundManager.PlaySound("bounce_sfx");
        if (col.gameObject.name == "Baller" && !score.isScored){
            Debug.Log("ground");
            score.lives--;
            score.livesText.text = score.lives.ToString();
            score.isScored = true;
        }
    }
}
