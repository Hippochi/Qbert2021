using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public Material Blue;
    public int firstTile = 1; //Prevent T1 from changing color at game start

    public AudioSource Sounder;
    public AudioClip CoilyJump;
    public AudioClip QbertJump;
    public AudioClip BallJump;

    void Update()
    {

        //if (PlayState.TilesToChange == 0)
        //{
        //    GetComponent<Animator>().enabled = true;
        //}
        //else GetComponent<Animator>().enabled = false;
    }

    private void OnCollisionEnter(Collision other) //for collision with any other game object
    {
        if (other.gameObject.tag == "Qbert") // OR other Qbert animations to be used later
        {
           
            if (firstTile == 0) // change a tile to have color code -1
            {
                GetComponent<Renderer>().material = Blue;
                PlayState.TilesToChange -= 1;

                PlayState.score += 25; // 25 points per tile
                Sounder.clip = QbertJump;
                Sounder.Play();
            }
            firstTile -= 1;
        }
        if (other.gameObject.tag == "Coily_Ball")
        {
            Sounder.clip = CoilyJump;
            Sounder.Play();
        }
        if (other.gameObject.tag == "Red_Ball_Bounce")
        {
            Sounder.clip = CoilyJump;
            Sounder.Play();
        }
        if (other.gameObject.tag == "Green_Ball_Bounce")
        {
            Sounder.clip = CoilyJump;
            Sounder.Play();
        }
    }
}
