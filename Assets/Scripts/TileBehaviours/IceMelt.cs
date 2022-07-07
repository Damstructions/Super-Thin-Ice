using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour
{
    public GameObject newTile;
    public GameObject GameController;
    public GameController _gameControl;

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.name == "PlayerCharacter")
        {
            Instantiate(newTile, transform.position, transform.rotation, GameController.transform);
            _gameControl.activeScore ++;
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameControl");
        _gameControl = GameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
