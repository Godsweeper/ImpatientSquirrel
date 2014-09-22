using UnityEngine;
using System.Collections;

//Class to define what a Tree consists of and allows for designers to create new puzzels without changing code
public class Tree : MonoBehaviour
{
    #region Public Variables
    public string treeName;         //Name of the Tree
    public Texture treeButton;      //Texture for the Tree's button
    public int treeNo,              //Number of the Tree(Order of progression)
               noOfPuzzles,         //Number of Puzzle's the Tree has(left in incase of different Tree's having different numbers)
               noOfGold,            //Number of Gold rewards the Tree has
               noOfSilver,          //Number of Silver rewards the Tree has
               noOfBronze;          //Number of Bronze rewards the Tree has
    //Transforms for a predefined number of Puzzles for a Tree (12)
    public Transform puzzle1, puzzle2, puzzle3, puzzle4, puzzle5, puzzle6, puzzle7, puzzle8, puzzle9, puzzle10, puzzle11, puzzle12;
    #endregion
}
