using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool grounded = true; //limits movement to only while touching ground
    public GameObject lastTile; //for use with coily target

    void Update()
    {
            if ((Input.GetKeyDown("[1]")) && (grounded == true)) //down left
            {
                grounded = false; 
                GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
            }

            if ((Input.GetKeyDown("[9]")) && (grounded == true)) //up right
            {
            grounded = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
            }

            if ((Input.GetKeyDown("[3]")) && (grounded == true)) //down right
            {
            grounded = false;
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
            }

            if ((Input.GetKeyDown("[7]")) && (grounded == true)) //up left
            {
            grounded = false;
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
            }
    }



    private void OnTriggerEnter(Collider other) //For landing on the ground or the elevator "drop off" points
    {
        if (other.tag == "Ground")
        {
            GetComponent<Transform>().position = new Vector3(0, 1, 0); 
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); 
            //"kills" qbert, resets his position and velocity

            PlayState.qbertLives -= 1;
        }

        if (other.tag == "Right_Elevator_Stop")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1); 
            //qbert gets shoved when the elevator reaches this zone
            
        }

        if (other.tag == "Left_Elevator_Stop")
        {StartCoroutine(deathTimer());
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
            //qbert gets shoved when the elevator reaches this zone
        }
    }


    private void OnCollisionEnter(Collision other)
    {

        grounded = true; //makes sure that qbert is considered grounded while on a tile, allowing movement

        if (other.gameObject.tag == "Red_Ball_Bounce") 
        {
            PlayState.death = true;
            PlayState.qbertLives -= 1;
            GetComponent<Transform>().position = new Vector3(0, 1, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(deathTimer());
            //kills qbert and resets his position
        }

        if (other.gameObject.tag == "Coily_Ball")
        {
            PlayState.death = true;
            PlayState.qbertLives -= 1;
            GetComponent<Transform>().position = new Vector3(0, 1, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(deathTimer());
            //kills qbert and resets his position
        }

        if (other.gameObject.tag == "tile")
        {
            lastTile = GameObject.FindWithTag("Target");
            lastTile.tag = "tile";
            other.gameObject.tag = "Target"; 
            //qbert is tracked through the last tile he had contact with
            //this resets the last tile he was on when he comes in contact with a new one then marks the current tile
        }
    }


    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(2f);
        PlayState.death = false;
        PlayState.doesCoilyExist = false;
        //turns off coilyball so it can spawn again after a delay
    }
}

