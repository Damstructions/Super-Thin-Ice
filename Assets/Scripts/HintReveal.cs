using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintReveal : MonoBehaviour
{
    public GameController _gameController;

    //array: Holds level text files
    public TextAsset nextLevelText;

    //converts the map file into a string
    public string nextLevelLines;

    //stores the prefabs with the different tile types
    public GameObject keyHintTile;
    public GameObject blank;
    GameObject outputTile;

    //The location the tiles spawn at, updates after each tile is spawned
    public Vector2 tileLoc;

    public int nextLevelNumber;

    public GameObject CheckForKey(int index)
    {
        char nextCode = nextLevelLines[index];

        //Compares it to the current tile code character being read
        if(nextCode == 'K')
        {
            //If it's a match, create an instance of that tile there
            outputTile = Instantiate(keyHintTile, new Vector2(_gameController.tileLoc.x, _gameController.tileLoc.y), Quaternion.identity);
        }

        return outputTile;
    }

    // Update is called once per frame
    void Update()
    {
        //nextLevelNumber = _gameController.levelNumber + 2;
        if(nextLevelNumber < 19)
        {
            nextLevelText = _gameController.levelTexts[nextLevelNumber];
            nextLevelLines = nextLevelText.text;
        }
        

    }
}
