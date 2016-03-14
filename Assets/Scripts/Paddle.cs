using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    //variables accessible in editor
    //[Range(0.5f,2f)]
    public float paddleSpeed = 1f;

    //starting vertical postition
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        //get new horiz. postion from an input device 
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);

        //Make new position clamped to sides
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);

        //set new position
        transform.position = playerPos;

    }
}