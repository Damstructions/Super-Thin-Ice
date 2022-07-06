using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject playerCharacter;

    public enum GameState {START, INSTRUCTIONS, PLAYING, FINISHED, END};
    GameObject firstState;
    GameObject secondState;
    public GameState currentState;

    GameObject ExitPoint;

    //array: Holds level text files
    public TextAsset[] levelTexts = new TextAsset[19];
    //gets the tile code to compare it to the TextAsset map file
    TileInformation thisTile;
    //converts the map file into a string
    string levelLines;
    //stores the prefabs with the different tile types
    public GameObject[] tilesTypes = new GameObject[10];
    //The location the tiles spawn at, updates after each tile is spawned
    public Vector2 tileLoc;

    public int levelNumber;
    float playTime = 0.0f;

    //Score at the beginning of the level
    int savedScore;
    //current score (not updated until level finished)
    int activeScore;

    //Holds the prefabs for the start and end screens.
    public GameObject startMenu;
    public GameObject instructionsMenu;
    public GameObject endScreen;

    public bool finishedGame = false;

    //function: check if character can move at all anymore and restart level if no - add this in separate script, call the restart function in this script then if needed.

    public void RestartLevel()
    {
        activeScore = savedScore;
        GenerateLevel();
    }

    public void NextLevel()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        tileLoc = new Vector2(0,0);
        levelNumber ++;
        savedScore = activeScore;

        //Updates the level to the new one
        levelLines = levelTexts[levelNumber].text;

        GenerateLevel();
    }

    void GenerateLevel()
    {
        //Cycles through the current level string to read each code
        for(int i = 0; i < levelLines.Length; i++)
        {
            //the current character code being read
            char thisCode = levelLines[i];

            //Cycles through the array of different tile types
            for(int x = 0; x < tilesTypes.Length; x++)
            {   
                //Moves to the start of a new row if previos one is maxed out
                if(tileLoc.x > 18)
                {
                    tileLoc.x = 0;//back to the beginning
                    tileLoc.y -= 1;//one lower
                }
                //Calls the information attached to the tile prefab being checked
                thisTile = tilesTypes[x].GetComponent<TileInformation>();

                //Compares it to the current tile code character being read
                if(thisCode == thisTile.tileCode)
                {
                    //If it's a match, create an instance of that tile there
                    Instantiate(tilesTypes[x], new Vector2(tileLoc.x, tileLoc.y), Quaternion.identity, this.transform);
                    //move over to the right for the next tile to spawn
                    tileLoc.x += 1;

                    //make sure the player is positioned in the start position
                    if(thisCode == 'P')
                    {

                        playerCharacter.transform.position = new Vector2(tileLoc.x-1, tileLoc.y);
                    }
                }
                
            }

        }
    }

    public void StartGame()
    {
        currentState = GameState.PLAYING;
        NextLevel();
        Destroy(secondState);
    }

    void EndGame()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        Instantiate(endScreen, new Vector2(0,0), Quaternion.identity);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = 0;
        savedScore = 0;
        currentState = GameState.START;
        firstState = Instantiate(startMenu, new Vector2(0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;

        if(Input.GetButtonDown("Submit"))
        {
            if(currentState == GameState.START)
            {
                currentState = GameState.INSTRUCTIONS;
                secondState = Instantiate(instructionsMenu, new Vector2(0,0), Quaternion.identity);
                Destroy(firstState);
            }
        }

        if(finishedGame){currentState = GameState.FINISHED;};

        if(currentState == GameState.FINISHED)
        {
            EndGame();
            finishedGame = false;
            currentState = GameState.END;
        }
        if(Input.GetButtonDown("Fire3") && levelNumber != 18)
        {
            NextLevel();
        }

    }
}
