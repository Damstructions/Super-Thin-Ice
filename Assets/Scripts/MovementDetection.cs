using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetection : MonoBehaviour
{

    public bool canMove;

    private void OnTriggerEnter2D(Collider2D other) {
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
