using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallBehaviour : MonoBehaviour
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
        //random number between 0(inclusive) and 2(exclusive)
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }

        if (other.gameObject.tag == "Qbert")
        {
            Destroy(gameObject);
            PlayState.enemiesFrozen = true;
            PlayState.score += 100;
            //gets rid of ball if collision occurs & adds points, add freeze all later
        }

    }

    private void OnTriggerEnter(Collider other)
    {                                      
        if (other.tag == "Ground") 
        {
            Destroy(gameObject);
            //gets rid of ball if collision occurs
        }
    }
}
