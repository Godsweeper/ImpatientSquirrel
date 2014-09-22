using UnityEngine;
using System.Collections;

public class EndPuzzleTrigger : Trigger 
{
    public Transform bronze, silver, gold;  //Transform Instances for the reward colours
    public int successColourChoice;         //The colour choice for the reward at the end of the puzzle


    //EndGameTrigger functionality
	//Problem:  Does not always fire
    public override void TriggerEffect(Collider2D coll)
    {
        //Trigger check
        if (triggerEntered == false)
        {
           // print("End Second:" + GameManager.Instance.second);
           // print("End Milisecond: " + GameManager.Instance.miliSecond);
           // print("End Time: " + GameManager.Instance.gameTimeString);
            print("End Game Trigger Hit");

            //If Gold is rewarded for the puzzle
            if (successColourChoice == 1)
            {
                //If the current reward colour is gold
                if (GameState.Instance.currentPuzzle.gold == false)
                {
                    //sets current puzzle to completed
                    GameState.Instance.currentPuzzle.completed = true;
                    //sets current puzzles gold to true
                    GameState.Instance.currentPuzzle.gold = true;                    
                    //adds 1 to the amount of golds the current tree has
                    GameState.Instance.currentTree.noOfGold++;
                    //Saves the updated acorn information
                    GameState.Instance.saveData.SaveAcorn(GameState.Instance.currentTree.treeNo, GameState.Instance.currentPuzzle.puzzleNo, 1);
                    GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 1, GameState.Instance.currentTree.noOfGold);
                    
                    //If the current Puzzle already has a silver reward
                    if (GameState.Instance.currentPuzzle.silver == true)
                    {
                        //Remove the silver reward and save data
                        GameState.Instance.currentTree.noOfSilver--;
                        GameState.Instance.currentPuzzle.silver = false;
                        GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 2, GameState.Instance.currentTree.noOfSilver);
                    }
                    //If the current Puzzle already has a bronze reward
                    if (GameState.Instance.currentPuzzle.bronze == true)
                    {
                        //Remove the bronze reward and save data
                        GameState.Instance.currentTree.noOfBronze--;
                        GameState.Instance.currentPuzzle.bronze = false;
                        GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 3, GameState.Instance.currentTree.noOfBronze);
                    }
                }
            }
            //If Silver is rewarded for the puzzle
            else if (successColourChoice == 2)
            {
                //If the current Puzzle doesnt already has a gold reward
                if (GameState.Instance.currentPuzzle.gold == false)
                {
                    //If the current Puzzle doesnt already has a silver reward
                    if (GameState.Instance.currentPuzzle.silver == false)
                    {
                        //sets current puzzle to completed with a silver reward
                        GameState.Instance.currentPuzzle.completed = true;
                        GameState.Instance.currentPuzzle.silver = true;
                        GameState.Instance.currentTree.noOfSilver++;
                        //Save Acorn data
                        GameState.Instance.saveData.SaveAcorn(GameState.Instance.currentTree.treeNo, GameState.Instance.currentPuzzle.puzzleNo, 2);
                        GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 2, GameState.Instance.currentTree.noOfSilver);
                        
                        //If the current Puzzle already has a bronze reward
                        if (GameState.Instance.currentPuzzle.bronze == true)
                        {
                            //Remove the bronze reward and save data
                            GameState.Instance.currentTree.noOfBronze--;
                            GameState.Instance.currentPuzzle.bronze = false;
                            GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 3, GameState.Instance.currentTree.noOfBronze);
                        }
                    }
                }
            }
            //If Bronze is rewarded for the puzzle
            else if (successColourChoice == 3)
            {
                //If the current Puzzle doesnt already has a gold reward
                if (GameState.Instance.currentPuzzle.gold == false)
                {
                    //If the current Puzzle doesnt already has a silver reward
                    if (GameState.Instance.currentPuzzle.silver == false)
                    {
                        //If the current Puzzle doesnt already has a bronze reward
                        if (GameState.Instance.currentPuzzle.bronze == false)
                        {
                            //Sets current puzzle to completed with a bronze ward
                            GameState.Instance.currentPuzzle.completed = true;
                            GameState.Instance.currentPuzzle.bronze = true;
                            GameState.Instance.currentTree.noOfBronze++;
                            //Save Acorn data
                            GameState.Instance.saveData.SaveAcorn(GameState.Instance.currentTree.treeNo, GameState.Instance.currentPuzzle.puzzleNo, 3);
                            GameState.Instance.saveData.SaveAcornAmount(GameState.Instance.currentTree.treeNo, 3, GameState.Instance.currentTree.noOfBronze);
                        }
                    }
                }
            }
            //If the current puzzle has not been completed before
            if (GameState.Instance.currentPuzzle.completed == false)
            {
                //set the puzzle to complete
                GameState.Instance.puzzlesCompleted++;
                GameState.Instance.currentPuzzle.completed = true;
            }
            //Set up End Game menu
            GameState.Instance.currentPuzzleAcornNo = successColourChoice;
            GameManager.Instance.sucessTimeCaption = GameManager.Instance.gameTimeString;
            Debug.Log("Finished at: " + GameManager.Instance.sucessTimeCaption);
            //Start End Game Menu
            GameManager.Instance.gameEnd = true;
            GameState.Instance.endGameMenu = true;
            //End trigger check
            triggerEntered = true;
        }
    }
    
    void Start()
    {
        //Choose a reward colour
        chooseReward(GameManager.Instance.gameTime);
    }

    void FixedUpdate()
    {
        //Choose a reward colour
        chooseReward(GameManager.Instance.gameTime);
    }

    //Chooses a reward colour
    void chooseReward(float gameTime)
    {
        //If the game time is greater than the gold time and less than the silver time
        if(gameTime >= GameState.Instance.currentPuzzle.goldTime && gameTime <= GameState.Instance.currentPuzzle.silverTime)
        {
            //Reward colour = Silver
            successColourChoice = 2;
            gold.gameObject.SetActive(false);
            silver.gameObject.SetActive(true);
            bronze.gameObject.SetActive(false);
        }
        //If the game time is greater than the Silver time
        else if (gameTime >= GameState.Instance.currentPuzzle.silverTime)
        {
            //Reward colour = Bronze
            successColourChoice = 3;
            gold.gameObject.SetActive(false);
            silver.gameObject.SetActive(false);
            bronze.gameObject.SetActive(true);
        }
        else
        {
            //Reward colour = Gold
            successColourChoice = 1;
            gold.gameObject.SetActive(true);
            silver.gameObject.SetActive(false);
            bronze.gameObject.SetActive(false);
            
        }
    }
}
