using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTile : MonoBehaviour
{
    public GameObject North;
    public GameObject South;
    public GameObject East;
    public GameObject West;

    public MovementDetection moveDirection;

    public GameObject playerCharacter;

    enum Directions {NORTH, SOUTH, EAST, WEST, NULL};

    Directions cameFrom;


    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCharacter.transform.position == North.transform.position)
        {
            cameFrom = Directions.NORTH;
            moveDirection = South.GetComponent<MovementDetection>();
        }
        else if(playerCharacter.transform.position == South.transform.position)
        {
            cameFrom = Directions.SOUTH;
            moveDirection = North.GetComponent<MovementDetection>();
        }
        else if(playerCharacter.transform.position ==  East.transform.position)
        {
            cameFrom = Directions.EAST;
            moveDirection = West.GetComponent<MovementDetection>();
        }
        else if(playerCharacter.transform.position == West.transform.position)
        {
            cameFrom = Directions.WEST;
            moveDirection = East.GetComponent<MovementDetection>();
        }
        
        if(moveDirection != null && playerCharacter.transform.position == transform.position)
        {
            switch(cameFrom)
            {
                case Directions.NORTH:
                    transform.position = new Vector2(transform.position.x, transform.position.y -1);
                    break;
                case Directions.SOUTH:
                    transform.position = new Vector2(transform.position.x, transform.position.y+1);
                    break;
                case Directions.EAST:
                    transform.position = new Vector2(transform.position.x -1, transform.position.y);
                    break;
                case Directions.WEST:
                    transform.position = new Vector2(transform.position.x +1, transform.position.y);
                    break;
            }
        }
    }
}
