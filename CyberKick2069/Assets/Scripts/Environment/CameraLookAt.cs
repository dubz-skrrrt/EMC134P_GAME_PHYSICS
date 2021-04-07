using UnityEngine;
// This complete script can be attached to a camera to make it
// continuously point at another object.

public class CameraLookAt : MonoBehaviour
{
    public float speed;

    void Update()
    {
     transform.Rotate(0,speed * Time.deltaTime, 0);
    }
}