using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallBehaviour : MonoBehaviour
{
    //public float yvalue;
    //bool anyTruers = false;
    
    void Update()
    {
       
        if (PlayState.death == true) 
        {
            Destroy(gameObject);
            //whenever player death occurs clear enemies
        }

        if (PlayState.coilyDied == true)
        {

            Debug.Log("Steven");
            Destroy(gameObject);
        }

        if (PlayState.enemiesFrozen == true)
        {
            //yvalue = GetComponent<Rigidbody>().velocity.y;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //anyTruers = true;
        }

        else 
        {
            
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            //if (anyTruers == true) GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, yvalue, GetComponent<Rigidbody>().velocity.z);
            //anyTruers = false; BALLS OFFSET YO

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
