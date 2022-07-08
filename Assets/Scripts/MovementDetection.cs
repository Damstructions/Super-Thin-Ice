using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetection : MonoBehaviour
{

    public bool canMove;

    public bool restrictedMovement;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(restrictedMovement == false)
        {
            if(other.gameObject.tag == "Walkable")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(restrictedMovement == true)
        {
            if(other.gameObject.tag == "Walkable")
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
    }
}
