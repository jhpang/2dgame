using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform LookAt;
    public float boundX = 5.0f;
    public float boundY = 5.0f;
    public float speed = 0.15f;

    private GameManager gm;
    private Vector3 desiredPosition;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float dx = LookAt.position.x - transform.position.x;
        //X Axis
        if (dx > boundX || dx < -boundX)
        {
            if (transform.position.x < LookAt.position.x)
            {
                delta.x = dx - boundX;
            }
            else
            {
                delta.x = dx + boundX;
            }
        }
        float dy = LookAt.position.y - transform.position.y;
        //Y Axis
        if (dy > boundY || dy < -boundY)
        {
            if (transform.position.y < LookAt.position.y)
            {
                delta.y = dy - boundY;
            }
            else
            {
                delta.y = dy + boundY;
            }
        }
//move Camera
        desiredPosition = transform.position + delta;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
        
    }
}
