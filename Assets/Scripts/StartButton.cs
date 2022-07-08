using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject GameController;
    public GameController _gameController;
    public Button startButtonComponent;

    // Start is called before the first frame update
    void Start()
    {
        
        GameController = GameObject.Find("GameControl");
        _gameController = GameController.GetComponent<GameController>();
    }

    public void StartGame()
    {
        _gameController.StartGame();
    }
}
