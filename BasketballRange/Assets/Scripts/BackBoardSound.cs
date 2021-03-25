using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoardSound : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        if (col.gameObject.name == "Baller"){
            Debug.Log("sup");
            SoundManager.PlaySound("bounceBackboard_sfx");
        }
    }
}
