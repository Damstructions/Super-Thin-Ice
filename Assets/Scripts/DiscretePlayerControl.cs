using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscretePlayerControl : MonoBehaviour
{
    public GameObject tileDetector;
    public MovementDetection moveCheck;
    public Rigidbody2D rb;

    float coolDown = 0f;

    bool coolingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Horizontal") > 0)
        {
            tileDetector.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        
        else if(Input.GetAxis("Horizontal") < 0)
        {
            tileDetector.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        }
        else if(Input.GetAxis("Vertical") > 0)
        {
            tileDetector.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            tileDetector.transform.position = new Vector2(transform.position.x, transform.position.y -1);
        }
        else
        {
            tileDetector.transform.position = new Vector2(transform.position.x, transform.position.y);
            moveCheck.canMove = false;
        }

        if(coolDown > 0.25f)
        {
            coolDown = 0.0f;
            coolingDown = false;
        }

        if(coolingDown == true)
        {
            coolDown += Time.deltaTime;
        }

        if(moveCheck.canMove == true && transform.position != tileDetector.transform.position && coolingDown == false){

            transform.position = new Vector2(tileDetector.transform.position.x, tileDetector.transform.position.y);
            coolingDown = true;
        }
    }
}
