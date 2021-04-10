using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElevatorBehaviour : MonoBehaviour
{

    public static bool rightAvailable = true;
    public AudioSource Sounder;
    public AudioClip ElevatorR;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Qbert")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 2, 0);
            rightAvailable = false;
            Sounder.clip = ElevatorR;
            Sounder.Play();
        }
        //if elevator collides with Qbert it moves to the top then goes offscreen
    }
}
