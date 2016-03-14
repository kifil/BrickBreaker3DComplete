using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticle;

    void OnCollisionEnter(Collision otherCollider)
    {
        //create particle effect
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        //tell the game manager what happened
        GM.instance.DestroyBrick();
        //dstroy itself
        Destroy(gameObject);
    }
}