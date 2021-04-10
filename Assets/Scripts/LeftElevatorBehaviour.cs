using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftElevatorBehaviour : MonoBehaviour
{

    public static bool leftAvailable = true;
    public AudioSource Sounder;
    public AudioClip ElevatorL;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Qbert")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 2);
            leftAvailable = false;
            Sounder.clip = ElevatorL;
            Sounder.Play();
        }
        //if elevator collides with Qbert it moves to the top then goes offscreen
        
    }
}
