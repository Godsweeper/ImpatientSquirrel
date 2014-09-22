using UnityEngine;
using System.Collections;

//Class to define what a Puzzle consists of and allows for designers to create new puzzels without changing code
public class Puzzle : MonoBehaviour
{
    #region Public Variables
    public string puzzleName;               //Name of the Puzzle    
    public int puzzleNo,                    //Number of the Puzzle(Order of progression)
               unlockNo;                    //Unlock Number of the Puzzle(The amount of puzzles completed required to unlock (Set to 0 for always unlocked))
    public Vector2 puzzleGridSize;          //The Grid Size of the Puzzle (2x3, 2x4, 3x3 etc...)
    public bool completed,                  //The Completed state of the puzzle
                bronze,                     //Check for if the player has gotten the Bronze reward for the Puzzle
                silver,                     //Check for if the player has gotten the Silver reward for the Puzzle
                gold,                       //Check for if the player has gotten the Gold reward for the Puzzle
                locked,                     //The Locked state of the Puzzle
                tutorial;                   //Check for if the Puzzle has a tutorial
    public int tutorialScreens;             //Number of tutorial screens 
    public Texture2D firstTutorialScreen,   //First tutorial screen texture
                     secondTutorialScreen;  //second tutorial screen texture
    public int bronzeTime,                  //Time in which the Puzzle is to be completed for the player to get the Bronze reward                         
               silverTime,                  //Time in which the Puzzle is to be completed for the player to get the Silver reward 
               goldTime;                    //Time in which the Puzzle is to be completed for the player to get the Gold reward 
    #endregion
}
