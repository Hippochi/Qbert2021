using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//

public class CoilyBallBehaviour : MonoBehaviour
{
    public GameObject TargetObj;
    public Vector3 coilyPos;
    public static bool isTracking = false;
    public Vector3 TargetPos;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Update()
    { 

        if (PlayState.death == true)
        {
            Destroy(gameObject);
            isTracking = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       
 

        if (isTracking == false)
        {

            if (other.gameObject.GetComponent<Bottom>().bottom == true)
            {
                
                isTracking = true;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 4, 0);
                ChangeSprite();
                
            }

            else //makes the decisions for coily when he is a ball state
            {
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
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    PlayState.doesCoilyExist = false;
                    isTracking = false;
                    Destroy(gameObject);
                }
            }
        }
        else //makes the decisions for coily's movement based on Qberts position
        {
            int x, y, z;
            TargetObj = GameObject.FindWithTag("Target");
            TargetPos = TargetObj.GetComponent<Transform>().position;
            coilyPos = other.gameObject.GetComponent<Transform>().position;
            
                if (TargetPos.y > coilyPos.y)
                {
                    y = 6;
                }
                else
                {
                    y = 4;
                }

                if (TargetPos.y == coilyPos.y)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        y = 4;

                    }
                    else
                    {
                        y = 6;


                    }
                }
                if (other.gameObject.GetComponent<Bottom>().bottom == true) { y = 6; } 
                //this errors the code if coily jumps of the pyramid, but can be easily fixed to respawn coily instead, which will be done in M3

                if (y == 6)
            {
                if (TargetPos.z == coilyPos.z)
                {
                    x = -1;
                    z = 0;
                }

                else if (TargetPos.z > coilyPos.z && TargetPos.x < coilyPos.x)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        x = -1;
                        z = 0;
                    }
                    else
                    {
                        x = 0;
                        z = 1;
                    }
                }

                else if (TargetPos.z < coilyPos.z && TargetPos.x < coilyPos.x) { x = -1; z = 0; }

                else { z = 1; x = 0; }
            }
            else
            {
                if (TargetPos.z == coilyPos.z)
                {
                    x = 1;
                    z = 0;
                }

                else if (TargetPos.z < coilyPos.z && TargetPos.x > coilyPos.x)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        x = 1;
                        z = 0;
                    }
                    else
                    {
                        x = 0;
                        z = -1;
                    }
                }

                else if (TargetPos.z > coilyPos.z && TargetPos.x > coilyPos.x) { x = 1; z = 0; }

                else { z = -1; x = 0; }


            }
            GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
        }



    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}

