using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingForce : MonoBehaviour
{
    public static Slider powSlider;
    private Image fill;
    private bool increaseForce = true;
    public Color minFillColor = new Color32(0, 242, 156, 150);
    public Color maxFillColor = new Color32(0, 255, 253, 150);
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        fill = GameObject.FindGameObjectWithTag("FillSlider").GetComponent<Image>();
        powSlider = GameObject.FindGameObjectWithTag("powerSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Shooting.directionFirst){
            MoveBar();
            UpdateFillbar();
        }
        
        
    }

    void MoveBar()
    {
        if(!Shooting.shoot && !Shooting.shootStart && !Shooting.forceSecond && TimerScript.timerIsRunning) 
        {
            if(powSlider.value < 1 && increaseForce) 
            {
                powSlider.value += 0.015f;
            }
            else
            {
                increaseForce = false;
                powSlider.value -= 0.015f;

                if (powSlider.value <= 0)
                {
                    increaseForce = true;
                }
            }
        }
        
    }

    void UpdateFillbar(){
        
        fill.color =  Color.Lerp(minFillColor, maxFillColor, powSlider.value);
    }
}
