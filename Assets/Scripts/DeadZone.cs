using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        //tell GM that a ball entered the trigger collider
        GM.instance.LoseLife();
    }
}