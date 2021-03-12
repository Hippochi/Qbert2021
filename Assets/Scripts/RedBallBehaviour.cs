using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallBehaviour : MonoBehaviour
{
    void Update()
    {
        if (PlayState.death == true) 
        {
            Destroy(gameObject);
            //whenever player death occurs clear enemies
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //choose between 2 different tiles to move towards
        if (Random.Range(0, 2) == 1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Qbert") || (other.tag == "Ground")) 
        {
            Destroy(gameObject);
            //gets rid of ball if collision occurs
        }
    }

}
