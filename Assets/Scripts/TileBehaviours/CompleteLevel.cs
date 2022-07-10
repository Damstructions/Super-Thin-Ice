using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    GameObject GameController;
    GameController _gameController;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "PlayerCharacter")
        {
            if(_gameController.levelNumber < 18)
            {
                _gameController.NextLevel();
                //Sound
                FindObjectOfType<AudioManager>().Play("Red Tile");
                //Sound
            }
            else
            {
                _gameController.finishedGame = true;
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameControl");
        _gameController = GameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
