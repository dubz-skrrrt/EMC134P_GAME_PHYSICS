using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CharacterChange : MonoBehaviour
{
    public Rigidbody[] charsList;
    public GameObject[] currentActiveChar;
    private int randCharNum;
    //public GameObject parentChar;
    private bool changeOnce;

    void Start(){
        
        charsList = GameObject.Find(this.gameObject.name).GetComponentsInChildren<Rigidbody>(true);
        currentActiveChar = GameObject.FindGameObjectsWithTag("character");

        changeOnce = false;
    }

    void Update(){
        if (!changeOnce){
            currentActiveChar = GameObject.FindGameObjectsWithTag("character");
            StartCoroutine(ChangeChar());
        }
            
    }


    IEnumerator ChangeChar(){
        changeOnce = true;
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < charsList.Length; i++){
            if (charsList[i].gameObject.activeInHierarchy){
                foreach (GameObject active in currentActiveChar){
                    active.SetActive(false);
                }
                
                }
            }
        randCharNum = Random.Range(0, charsList.Length);
        charsList[randCharNum].gameObject.SetActive(true);
        changeOnce = false;
    }

}
