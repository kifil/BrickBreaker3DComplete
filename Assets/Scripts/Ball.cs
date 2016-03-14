using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 600f;


    private Rigidbody myRigidBodyComponent;
    private bool ballInPlay;

    void Awake()
    {
        //get the rigid body so we can modify it
        myRigidBodyComponent = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //default left click or control
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            //free ball from parent
            transform.parent = null;
            ballInPlay = true;

            //let the physics engine handle ball movement
            myRigidBodyComponent.isKinematic = false;

            myRigidBodyComponent.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
}