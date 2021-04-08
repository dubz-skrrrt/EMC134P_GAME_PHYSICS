using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimResultsScript : MonoBehaviour
{
    public Animator playerCelebrationAnim;
    private int randCelebAnim;
    private bool randomOnce;
    void Start(){
        playerCelebrationAnim.SetBool("Defeat", false);
        playerCelebrationAnim.SetBool("Celebrate Once", false);
        randomOnce = false;
    }
    void Update(){

        if (!randomOnce){
            if (UIText.lose){
                playerCelebrationAnim.SetBool("Defeat", true);
                UIText.lose = false;
            }
            else{
                
                randCelebAnim = Random.Range(1,4);
                Debug.Log(randCelebAnim);
                playerCelebrationAnim.SetInteger("Celebration1", randCelebAnim);    
                playerCelebrationAnim.SetBool("Celebrate Once", true);           
            }
            randomOnce = true;  
            //playerCelebrationAnim.SetBool("Celebrate Once", false); 
            
        }
        
    }
}
