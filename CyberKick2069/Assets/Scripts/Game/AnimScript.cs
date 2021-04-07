using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    private Animator playerAnim;
    public static bool kickAnim;
    void Start(){
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        kickAnim = false;
    }
    void Update(){
        if (Shooting.shootStart){
            OnShootStart();
        }
    }
    void OnShootStart(){
        playerAnim.SetBool("KickStart", true);
        
    }
    void BallShoot(){
        kickAnim = true;
    }
    void StopShootAnim(){
        playerAnim.SetBool("KickStart", false);
        
    }
}
