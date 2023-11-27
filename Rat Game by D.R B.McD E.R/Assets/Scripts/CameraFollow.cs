using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            //Reference to the player's Transform
    public float smoothSpeed = 0.125f;  //Smoothing factor for camera movement
    public Vector3 offset;              //Offset from the player position

    void LateUpdate()
    {
        if (target != null)
        {
            //Calculates the desired position for camera
            Vector3 desiredPosition = target.position + offset;

            //Smoothly move camera towards desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            //Make camera look at player
            transform.LookAt(target);
        }
    }
}