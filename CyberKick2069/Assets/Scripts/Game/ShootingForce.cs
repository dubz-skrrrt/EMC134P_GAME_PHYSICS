using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingForce : MonoBehaviour
{
    public static Slider powSlider;
    private bool increaseForce = true;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        powSlider = GameObject.FindGameObjectWithTag("powerSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBar();
        
    }

    void MoveBar()
    {
        if(!Shooting.shoot && !Shooting.shootStart) 
        {
            if(powSlider.value < 1 && increaseForce) 
            {
                powSlider.value += 0.005f;
            }
            else
            {
                increaseForce = false;
                powSlider.value -= 0.005f;

                if (powSlider.value <= 0)
                {
                    increaseForce = true;
                }
            }
        }
        
    }
}
