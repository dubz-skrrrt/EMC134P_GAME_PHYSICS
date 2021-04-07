using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Vector3 arrow_from = new Vector3(0.0F, 45.0F, 0.0F);
    [SerializeField] private Vector3 arrow_to = new Vector3(0.0F, -45.0F, 0.0F);
    [SerializeField] private float arrow_speed = 0.5F;

 
    void Update() {
        if (!Shooting.shoot && !Shooting.shootStart && !Shooting.directionFirst){
            
            DirectionToShoot();
        }
    }

    void DirectionToShoot(){
        Quaternion from = Quaternion.Euler(this.arrow_from);
        Quaternion to = Quaternion.Euler(this.arrow_to);
 
        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.arrow_speed));
        this.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }


}
