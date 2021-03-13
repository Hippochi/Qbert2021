using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public Material Blue;
    public int firstTile = 1; //Prevent T1 from changing color at game start

    private void OnCollisionEnter(Collision other) //for collision with any other game object
    {
        if (other.gameObject.tag == "Qbert") // OR other Qbert animations to be used later
        {
           
            if (firstTile == 0) // change a tile to have color code -1
            {
                GetComponent<Renderer>().material = Blue;
                PlayState.TilesToChange -= 1;

                PlayState.score += 25; // 25 points per tile
                Debug.Log(PlayState.score);
            }
            firstTile -= 1;
        }
    }
}
