using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    private Animator playerAnim;
    public Animator crowdAnim;
    private bool playOnce;
    private int crowdRandAnim;
    public static bool kickAnim;
    
    void Start(){
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        crowdAnim = this.gameObject.GetComponent<Animator>();
        if (crowdAnim !=null){
            return;
        }
        if (playerAnim !=null){
            return;
        }else{
            Debug.Log("No Player");
        }
        kickAnim = false;

    }
    void Update(){
        if (!playOnce){
            crowdRandAnim = Random.Range(0, 4);
            crowdAnim.SetInteger("CrowdAnim", crowdRandAnim);
            StartCoroutine(DelayAnim());
            playOnce = true;
        }else{
            StartCoroutine(ChangeDelayAnim());
        }
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

    IEnumerator DelayAnim(){
        yield return new WaitForSeconds(4f);
        crowdAnim.SetBool("ChangeAnim", true);
    }
    IEnumerator ChangeDelayAnim(){
        playOnce = false;
        yield return new WaitForSeconds(4f);
        
    }
}
