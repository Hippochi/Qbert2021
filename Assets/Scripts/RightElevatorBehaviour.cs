using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightElevatorBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Qbert")
        GetComponent<Rigidbody>().velocity = new Vector3(-2, 2, 0);
        //if elevator collides with Qbert it moves to the top then destroys itself
    }
}
