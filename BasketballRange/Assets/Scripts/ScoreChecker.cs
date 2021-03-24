using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public bool underBasket = false;
    public Scoring S;
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Check");
        if (col.gameObject.name == "Baller" && underBasket == false && S.isScored == false){
            underBasket = true;
            
        }
    }
}
