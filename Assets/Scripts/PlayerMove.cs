using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isGrounded = true; //limits movement to only while touching ground
    public GameObject lastTile; //for use with coily target
    public GameObject swearBubble;
    public AudioSource Sounder;
    public AudioClip coilyqbert;
    public AudioClip GreenyQ;
    public AudioClip bigDie;

    void Update()
    {
        if (GetComponent<Rigidbody>().velocity != new Vector3(0,0,0)) isGrounded = false;
        else isGrounded = true;

            if ((Input.GetKeyDown("[1]")) && (isGrounded == true)) //down left
            {
               
                GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
            }

            if ((Input.GetKeyDown("[9]")) && (isGrounded == true)) //up right
            {
            
            GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
            }

            if ((Input.GetKeyDown("[3]")) && (isGrounded == true)) //down right
            {
            
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
            }

            if ((Input.GetKeyDown("[7]")) && (isGrounded == true)) //up left
            {
           
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
            }
            
    }



    private void OnTriggerEnter(Collider other) //For landing on the ground or the elevator "drop off" points
    {
        if (other.tag == "Ground")
        {
            Sounder.clip = bigDie;
            Sounder.Play();
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
        { 
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
            //qbert gets shoved when the elevator reaches this zone
        }
    }


    private void OnCollisionEnter(Collision other)
    {

        //makes sure that qbert is considered isGrounded while on a tile, allowing movement

        if (other.gameObject.tag == "Red_Ball_Bounce")
        {
            Sounder.clip = bigDie;
            Sounder.Play();
            StartCoroutine(deathTimer());
            //kills qbert and resets his position
        }

        if (other.gameObject.tag == "Green_Ball_Bounce")
        {
            Sounder.clip = GreenyQ;
            Sounder.Play();
        }

        if (other.gameObject.tag == "Coily_Ball")
        {
            Sounder.clip = coilyqbert;
            Sounder.Play();
            PlayState.coilyDied = true;
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
        PlayState.death = true;
        PlayState.qbertLives -= 1;
        swearBubble.GetComponent<SpriteRenderer>().enabled = true;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        GetComponent<Transform>().position = GameObject.FindWithTag("Target").GetComponent<Transform>().position + new Vector3(0, 1, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        PlayState.death = false;
        PlayState.doesCoilyExist = false;
        swearBubble.GetComponent<SpriteRenderer>().enabled = false;
        //turns off coilyball so it can spawn again after a delay
    }
}

