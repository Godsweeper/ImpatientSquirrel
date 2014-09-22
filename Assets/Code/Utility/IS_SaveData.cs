using UnityEngine;
using System.Collections;

public class IS_SaveData : SaveData
{
    // SAVING DATA \\
    //Save First Play Bool
    public void SaveFirstPlay(bool firstPlayBool)
    {
        SaveBool("First_Play", firstPlayBool);
    }
    //Save SFX Option
    public void SaveSFXOption(bool sfxOption)
    {
        SaveBool("SFX_Option", sfxOption);
    }
    //Save Music Option
    public void SaveMusicOption(bool musicOption)
    {
        SaveBool("Music_Option", musicOption);
    }
    //Save Push Notification Option
    public void SavePushNotificationOption(bool pnOption)
    {
        SaveBool("PN_Option", pnOption);
    }
    //Save the current Crystal Nut Amount
    public void SaveCrystalNutAmount(int nutCount)
    {
        SaveInt("Crystal_Nut_Amount", nutCount);
    }
    //Save the current Slow Time Nut Amount
    public void SaveSlowTimeNutAmount(int nutCount)
    {
        SaveInt("Slow_Time_Nut_Amount", nutCount);
    }
    //Save the current Rewind Nut Amount
    public void SaveRewindNutAmount(int nutCount)
    {
        SaveInt("Rewind_Nut_Amount", nutCount);
    }

    public void SaveAcorn(int treeNo, int puzzleNo, int acornColour)
    {
        //if tree is the first tree
        if (treeNo == 1)
        {
            if (puzzleNo == 1)
            {
                SaveInt("TreeOne_PuzzleOne_Acorn", acornColour);
            }
            else if (puzzleNo == 2)
            {
                SaveInt("TreeOne_PuzzleTwo_Acorn", acornColour);
            }
            else if (puzzleNo == 3)
            {
                SaveInt("TreeOne_PuzzleThree_Acorn", acornColour);
            }
            else if (puzzleNo == 4)
            {
                SaveInt("TreeOne_PuzzleFour_Acorn", acornColour);
            }
            else if (puzzleNo == 5)
            {
                SaveInt("TreeOne_PuzzleFive_Acorn", acornColour);
            }
            else if (puzzleNo == 6)
            {
                SaveInt("TreeOne_PuzzleSix_Acorn", acornColour);
            }
            else if (puzzleNo == 7)
            {
                SaveInt("TreeOne_PuzzleSeven_Acorn", acornColour);
            }
            else if (puzzleNo == 8)
            {
                SaveInt("TreeOne_PuzzleEight_Acorn", acornColour);
            }
            else if (puzzleNo == 9)
            {
                SaveInt("TreeOne_PuzzleNine_Acorn", acornColour);
            }
            else if (puzzleNo == 10)
            {
                SaveInt("TreeOne_PuzzleTen_Acorn", acornColour);
            }
            else if (puzzleNo == 11)
            {
                SaveInt("TreeOne_PuzzleEleven_Acorn", acornColour);
            }
            else if (puzzleNo == 12)
            {
                SaveInt("TreeOne_PuzzleTwelve_Acorn", acornColour);
            }
        }
        else if (treeNo == 2)
        {
            if (puzzleNo == 1)
            {
                SaveInt("TreeTwo_PuzzleOne_Acorn", acornColour);
            }
            else if (puzzleNo == 2)
            {
                SaveInt("TreeTwo_PuzzleTwo_Acorn", acornColour);
            }
            else if (puzzleNo == 3)
            {
                SaveInt("TreeTwo_PuzzleThree_Acorn", acornColour);
            }
            else if (puzzleNo == 4)
            {
                SaveInt("TreeTwo_PuzzleFour_Acorn", acornColour);
            }
            else if (puzzleNo == 5)
            {
                SaveInt("TreeTwo_PuzzleFive_Acorn", acornColour);
            }
            else if (puzzleNo == 6)
            {
                SaveInt("TreeTwo_PuzzleSix_Acorn", acornColour);
            }
            else if (puzzleNo == 7)
            {
                SaveInt("TreeTwo_PuzzleSeven_Acorn", acornColour);
            }
            else if (puzzleNo == 8)
            {
                SaveInt("TreeTwo_PuzzleEight_Acorn", acornColour);
            }
            else if (puzzleNo == 9)
            {
                SaveInt("TreeTwo_PuzzleNine_Acorn", acornColour);
            }
            else if (puzzleNo == 10)
            {
                SaveInt("TreeTwo_PuzzleTen_Acorn", acornColour);
            }
            else if (puzzleNo == 11)
            {
                SaveInt("TreeTwo_PuzzleEleven_Acorn", acornColour);
            }
            else if (puzzleNo == 12)
            {
                SaveInt("TreeTwo_PuzzleTwelve_Acorn", acornColour);
            }
        }
        if (treeNo == 3)
        {
            if (puzzleNo == 1)
            {
                SaveInt("TreeThree_PuzzleOne_Acorn", acornColour);
            }
            else if (puzzleNo == 2)
            {
                SaveInt("TreeThree_PuzzleTwo_Acorn", acornColour);
            }
            else if (puzzleNo == 3)
            {
                SaveInt("TreeThree_PuzzleThree_Acorn", acornColour);
            }
            else if (puzzleNo == 4)
            {
                SaveInt("TreeThree_PuzzleFour_Acorn", acornColour);
            }
            else if (puzzleNo == 5)
            {
                SaveInt("TreeThree_PuzzleFive_Acorn", acornColour);
            }
            else if (puzzleNo == 6)
            {
                SaveInt("TreeThree_PuzzleSix_Acorn", acornColour);
            }
            else if (puzzleNo == 7)
            {
                SaveInt("TreeThree_PuzzleSeven_Acorn", acornColour);
            }
            else if (puzzleNo == 8)
            {
                SaveInt("TreeThree_PuzzleEight_Acorn", acornColour);
            }
            else if (puzzleNo == 9)
            {
                SaveInt("TreeThree_PuzzleNine_Acorn", acornColour);
            }
            else if (puzzleNo == 10)
            {
                SaveInt("TreeThree_PuzzleTen_Acorn", acornColour);
            }
            else if (puzzleNo == 11)
            {
                SaveInt("TreeThree_PuzzleEleven_Acorn", acornColour);
            }
            else if (puzzleNo == 12)
            {
                SaveInt("TreeThree_PuzzleTwelve_Acorn", acornColour);
            }
        }
        if (treeNo == 4)
        {
            if (puzzleNo == 1)
            {
                SaveInt("TreeFour_PuzzleOne_Acorn", acornColour);
            }
            else if (puzzleNo == 2)
            {
                SaveInt("TreeFour_PuzzleTwo_Acorn", acornColour);
            }
            else if (puzzleNo == 3)
            {
                SaveInt("TreeFour_PuzzleThree_Acorn", acornColour);
            }
            else if (puzzleNo == 4)
            {
                SaveInt("TreeFour_PuzzleFour_Acorn", acornColour);
            }
            else if (puzzleNo == 5)
            {
                SaveInt("TreeFour_PuzzleFive_Acorn", acornColour);
            }
            else if (puzzleNo == 6)
            {
                SaveInt("TreeFour_PuzzleSix_Acorn", acornColour);
            }
            else if (puzzleNo == 7)
            {
                SaveInt("TreeFour_PuzzleSeven_Acorn", acornColour);
            }
            else if (puzzleNo == 8)
            {
                SaveInt("TreeFour_PuzzleEight_Acorn", acornColour);
            }
            else if (puzzleNo == 9)
            {
                SaveInt("TreeFour_PuzzleNine_Acorn", acornColour);
            }
            else if (puzzleNo == 10)
            {
                SaveInt("TreeFour_PuzzleTen_Acorn", acornColour);
            }
            else if (puzzleNo == 11)
            {
                SaveInt("TreeFour_PuzzleEleven_Acorn", acornColour);
            }
            else if (puzzleNo == 12)
            {
                SaveInt("TreeFour_PuzzleTwelve_Acorn", acornColour);
            }
        }
        if (treeNo == 5)
        {
            if (puzzleNo == 1)
            {
                SaveInt("TreeFive_PuzzleOne_Acorn", acornColour);
            }
            else if (puzzleNo == 2)
            {
                SaveInt("TreeFive_PuzzleTwo_Acorn", acornColour);
            }
            else if (puzzleNo == 3)
            {
                SaveInt("TreeFive_PuzzleThree_Acorn", acornColour);
            }
            else if (puzzleNo == 4)
            {
                SaveInt("TreeFive_PuzzleFour_Acorn", acornColour);
            }
            else if (puzzleNo == 5)
            {
                SaveInt("TreeFive_PuzzleFive_Acorn", acornColour);
            }
            else if (puzzleNo == 6)
            {
                SaveInt("TreeFive_PuzzleSix_Acorn", acornColour);
            }
            else if (puzzleNo == 7)
            {
                SaveInt("TreeFive_PuzzleSeven_Acorn", acornColour);
            }
            else if (puzzleNo == 8)
            {
                SaveInt("TreeFive_PuzzleEight_Acorn", acornColour);
            }
            else if (puzzleNo == 9)
            {
                SaveInt("TreeFive_PuzzleNine_Acorn", acornColour);
            }
            else if (puzzleNo == 10)
            {
                SaveInt("TreeFive_PuzzleTen_Acorn", acornColour);
            }
            else if (puzzleNo == 11)
            {
                SaveInt("TreeFive_PuzzleEleven_Acorn", acornColour);
            }
            else if (puzzleNo == 12)
            {
                SaveInt("TreeFive_PuzzleTwelve_Acorn", acornColour);
            }
        }   
    }

    public void SaveAcornAmount(int treeNo, int acornColour, int acornAmount)
    {
        //if acorn number is gold
        if(treeNo == 1)
        {
            if(acornColour == 1)
            {
                SaveInt("TreeOne_NoOfGold", acornAmount);
            }
            if (acornColour == 2)
            {
                SaveInt("TreeOne_NoOfSilver", acornAmount);
            }
            if (acornColour == 3)
            {
                SaveInt("TreeOne_NoOfBronze", acornAmount);
            }
        }
        else if (treeNo == 2)
        {
            if (acornColour == 1)
            {
                SaveInt("TreeTwo_NoOfGold", acornAmount);
            }
            if (acornColour == 2)
            {
                SaveInt("TreeTwo_NoOfSilver", acornAmount);
            }
            if (acornColour == 3)
            {
                SaveInt("TreeTwo_NoOfBronze", acornAmount);
            }
        }
        else if (treeNo == 3)
        {
            if (acornColour == 1)
            {
                SaveInt("TreeThree_NoOfGold", acornAmount);
            }
            if (acornColour == 2)
            {
                SaveInt("TreeThree_NoOfSilver", acornAmount);
            }
            if (acornColour == 3)
            {
                SaveInt("TreeThree_NoOfBronze", acornAmount);
            }
        }
        else if (treeNo == 4)
        {
            if (acornColour == 1)
            {
                SaveInt("TreeFour_NoOfGold", acornAmount);
            }
            if (acornColour == 2)
            {
                SaveInt("TreeFour_NoOfSilver", acornAmount);
            }
            if (acornColour == 3)
            {
                SaveInt("TreeFour_NoOfBronze", acornAmount);
            }
        }
        else if (treeNo == 5)
        {
            if (acornColour == 1)
            {
                SaveInt("TreeFive_NoOfGold", acornAmount);
            }
            if (acornColour == 2)
            {
                SaveInt("TreeFive_NoOfSilver", acornAmount);
            }
            if (acornColour == 3)
            {
                SaveInt("TreeFive_NoOfBronze", acornAmount);
            }
        }
    }
    
    // LOADING DATA \\
    public void LoadFirstPlay()
    {
        if (GetSavedBool("First_Play") != null)
        {
            GameState.Instance.firstPlay = (bool)GetSavedBool("First_Play");
        }
    }

    public void LoadOptions()
    {
        if (GetSavedBool("SFX_Option") != null)
        {
            AudioManager.Instance.sfxOn  = (bool)GetSavedBool("SFX_Option");
        }
        if (GetSavedBool("Music_Option") != null)
        {
            AudioManager.Instance.musicOn = (bool)GetSavedBool("Music_Option");
        }
        if (GetSavedBool("PN_Option") != null)
        {
            AudioManager.Instance.pNOn = (bool)GetSavedBool("PN_Option");
        }                
    }

    public void LoadNutInventory()
    {
        if (GetSavedInt("Crystal_Nut_Amount") != null)
        {
            GameState.Instance.playerInventory.crystalNutCount = (int)GetSavedInt("Crystal_Nut_Amount");
        }
        if (GetSavedInt("Rewind_Nut_Amount") != null)
        {
            GameState.Instance.playerInventory.rewindNutCount = (int)GetSavedInt("Rewind_Nut_Amount");
        }
        if (GetSavedInt("Slow_Time_Nut_Amount") != null)
        {
            GameState.Instance.playerInventory.slowTimeNutCount = (int)GetSavedInt("Slow_Time_Nut_Amount");
        }
    }

    //Loads all data to do with Acorn progression 
    public void LoadAcornData()
    {
        //loads the amount of acorns each tree has of each type
        LoadNoOfAcornData();
        //loads what acorn colour each puzzle in each tree has
        LoadTreeProgression();
    }

    private void LoadTreeProgression()
    {
        LoadTreeOneProgression();
        LoadTreeTwoProgression();
        LoadTreeThreeProgression();
        LoadTreeFourProgression();
    }

    private void LoadTreeOneProgression()
    {
        // TREE ONE \\
        //Puzzle One
        if(GetSavedInt("TreeOne_PuzzleOne_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle1.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleOne_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle1.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleOne_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle1.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleOne_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle1.GetComponent<Puzzle>().bronze = true;
            }            
        }

        //Puzzle Two
        if (GetSavedInt("TreeOne_PuzzleTwo_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle2.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleTwo_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle2.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTwo_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle2.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTwo_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle2.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Three
        if (GetSavedInt("TreeOne_PuzzleThree_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle3.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleThree_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle3.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleThree_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle3.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleThree_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle3.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Four
        if (GetSavedInt("TreeOne_PuzzleFour_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle4.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleFour_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle4.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleFour_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle4.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleFour_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle4.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Five
        if (GetSavedInt("TreeOne_PuzzleFive_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle5.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleFive_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle5.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleFive_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle5.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleFive_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle5.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Six
        if (GetSavedInt("TreeOne_PuzzleSix_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle6.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleSix_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle6.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleSix_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle6.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleSix_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle6.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Seven
        if (GetSavedInt("TreeOne_PuzzleSeven_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle7.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleSeven_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle7.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleSeven_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle7.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleSeven_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle7.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eight
        if (GetSavedInt("TreeOne_PuzzleEight_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle8.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleEight_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle8.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleEight_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle8.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleEight_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle8.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Nine
        if (GetSavedInt("TreeOne_PuzzleNine_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle9.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleNine_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle9.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleNine_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle9.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleNine_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle9.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Ten
        if (GetSavedInt("TreeOne_PuzzleTen_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle10.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleTen_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle10.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTen_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle10.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTen_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle10.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eleven
        if (GetSavedInt("TreeOne_PuzzleEleven_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle11.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleEleven_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle11.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleEleven_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle11.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleEleven_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle11.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Twelve
        if (GetSavedInt("TreeOne_PuzzleTwelve_Acorn") != null)
        {
            GameState.Instance.tree1.puzzle12.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeOne_PuzzleTwelve_Acorn") == 1)
            {
                GameState.Instance.tree1.puzzle12.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTwelve_Acorn") == 2)
            {
                GameState.Instance.tree1.puzzle12.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeOne_PuzzleTwelve_Acorn") == 3)
            {
                GameState.Instance.tree1.puzzle12.GetComponent<Puzzle>().bronze = true;
            }
        }
    }

    private void LoadTreeTwoProgression()
    {
        // TREE Two \\
        //Puzzle Two
        if (GetSavedInt("TreeTwo_PuzzleOne_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle1.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleOne_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle1.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleOne_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle1.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleOne_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle1.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Two
        if (GetSavedInt("TreeTwo_PuzzleTwo_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle2.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleTwo_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle2.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTwo_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle2.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTwo_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle2.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Three
        if (GetSavedInt("TreeTwo_PuzzleThree_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle3.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleThree_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle3.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleThree_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle3.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleThree_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle3.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Four
        if (GetSavedInt("TreeTwo_PuzzleFour_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle4.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleFour_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle4.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleFour_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle4.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleFour_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle4.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Five
        if (GetSavedInt("TreeTwo_PuzzleFive_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle5.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleFive_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle5.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleFive_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle5.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleFive_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle5.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Six
        if (GetSavedInt("TreeTwo_PuzzleSix_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle6.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleSix_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle6.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleSix_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle6.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleSix_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle6.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Seven
        if (GetSavedInt("TreeTwo_PuzzleSeven_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle7.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleSeven_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle7.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleSeven_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle7.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleSeven_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle7.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eight
        if (GetSavedInt("TreeTwo_PuzzleEight_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle8.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleEight_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle8.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleEight_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle8.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleEight_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle8.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Nine
        if (GetSavedInt("TreeTwo_PuzzleNine_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle9.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleNine_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle9.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleNine_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle9.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleNine_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle9.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Ten
        if (GetSavedInt("TreeTwo_PuzzleTen_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle10.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleTen_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle10.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTen_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle10.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTen_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle10.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eleven
        if (GetSavedInt("TreeTwo_PuzzleEleven_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle11.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleEleven_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle11.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleEleven_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle11.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleEleven_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle11.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Twelve
        if (GetSavedInt("TreeTwo_PuzzleTwelve_Acorn") != null)
        {
            GameState.Instance.tree2.puzzle12.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeTwo_PuzzleTwelve_Acorn") == 1)
            {
                GameState.Instance.tree2.puzzle12.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTwelve_Acorn") == 2)
            {
                GameState.Instance.tree2.puzzle12.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeTwo_PuzzleTwelve_Acorn") == 3)
            {
                GameState.Instance.tree2.puzzle12.GetComponent<Puzzle>().bronze = true;
            }
        }
    }

    private void LoadTreeThreeProgression()
    {
        // TREE THREE \\
        //Puzzle One
        if (GetSavedInt("TreeThree_PuzzleOne_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle1.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleOne_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle1.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleOne_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle1.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleOne_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle1.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Two
        if (GetSavedInt("TreeThree_PuzzleTwo_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle2.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleTwo_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle2.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTwo_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle2.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTwo_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle2.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Three
        if (GetSavedInt("TreeThree_PuzzleThree_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle3.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleThree_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle3.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleThree_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle3.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleThree_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle3.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Four
        if (GetSavedInt("TreeThree_PuzzleFour_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle4.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleFour_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle4.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleFour_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle4.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleFour_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle4.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Five
        if (GetSavedInt("TreeThree_PuzzleFive_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle5.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleFive_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle5.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleFive_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle5.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleFive_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle5.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Six
        if (GetSavedInt("TreeThree_PuzzleSix_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle6.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleSix_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle6.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleSix_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle6.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleSix_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle6.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Seven
        if (GetSavedInt("TreeThree_PuzzleSeven_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle7.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleSeven_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle7.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleSeven_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle7.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleSeven_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle7.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eight
        if (GetSavedInt("TreeThree_PuzzleEight_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle8.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleEight_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle8.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleEight_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle8.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleEight_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle8.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Nine
        if (GetSavedInt("TreeThree_PuzzleNine_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle9.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleNine_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle9.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleNine_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle9.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleNine_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle9.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Ten
        if (GetSavedInt("TreeThree_PuzzleTen_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle10.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleTen_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle10.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTen_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle10.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTen_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle10.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eleven
        if (GetSavedInt("TreeThree_PuzzleEleven_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle11.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleEleven_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle11.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleEleven_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle11.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleEleven_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle11.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Twelve
        if (GetSavedInt("TreeThree_PuzzleTwelve_Acorn") != null)
        {
            GameState.Instance.tree3.puzzle12.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeThree_PuzzleTwelve_Acorn") == 1)
            {
                GameState.Instance.tree3.puzzle12.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTwelve_Acorn") == 2)
            {
                GameState.Instance.tree3.puzzle12.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeThree_PuzzleTwelve_Acorn") == 3)
            {
                GameState.Instance.tree3.puzzle12.GetComponent<Puzzle>().bronze = true;
            }
        }
    }

    private void LoadTreeFourProgression()
    {
        // TREE FOUR \\
        //Puzzle One
        if (GetSavedInt("TreeFour_PuzzleOne_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle1.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleOne_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle1.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleOne_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle1.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleOne_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle1.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Two
        if (GetSavedInt("TreeFour_PuzzleTwo_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle2.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleTwo_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle2.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTwo_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle2.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTwo_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle2.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Three
        if (GetSavedInt("TreeFour_PuzzleThree_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle3.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleThree_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle3.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleThree_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle3.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleThree_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle3.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Four
        if (GetSavedInt("TreeFour_PuzzleFour_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle4.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleFour_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle4.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleFour_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle4.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleFour_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle4.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Five
        if (GetSavedInt("TreeFour_PuzzleFive_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle5.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleFive_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle5.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleFive_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle5.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleFive_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle5.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Six
        if (GetSavedInt("TreeFour_PuzzleSix_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle6.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleSix_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle6.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleSix_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle6.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleSix_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle6.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Seven
        if (GetSavedInt("TreeFour_PuzzleSeven_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle7.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleSeven_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle7.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleSeven_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle7.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleSeven_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle7.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eight
        if (GetSavedInt("TreeFour_PuzzleEight_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle8.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleEight_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle8.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleEight_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle8.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleEight_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle8.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Nine
        if (GetSavedInt("TreeFour_PuzzleNine_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle9.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleNine_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle9.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleNine_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle9.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleNine_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle9.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Ten
        if (GetSavedInt("TreeFour_PuzzleTen_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle10.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleTen_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle10.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTen_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle10.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTen_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle10.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Eleven
        if (GetSavedInt("TreeFour_PuzzleEleven_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle11.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleEleven_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle11.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleEleven_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle11.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleEleven_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle11.GetComponent<Puzzle>().bronze = true;
            }
        }

        //Puzzle Twelve
        if (GetSavedInt("TreeFour_PuzzleTwelve_Acorn") != null)
        {
            GameState.Instance.tree4.puzzle12.GetComponent<Puzzle>().completed = true;
            if (GetSavedInt("TreeFour_PuzzleTwelve_Acorn") == 1)
            {
                GameState.Instance.tree4.puzzle12.GetComponent<Puzzle>().gold = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTwelve_Acorn") == 2)
            {
                GameState.Instance.tree4.puzzle12.GetComponent<Puzzle>().silver = true;
            }
            else if (GetSavedInt("TreeFour_PuzzleTwelve_Acorn") == 3)
            {
                GameState.Instance.tree4.puzzle12.GetComponent<Puzzle>().bronze = true;
            }
        }
    }

    /*private void LoadTreeFiveProgression()
    {
        // TREE Five \\
        //Puzzle One
     
        if (GetSavedInt("TreeFive_PuzzleOne_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle1.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleOne_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle1.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleOne_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle1.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Two
        if (GetSavedInt("TreeFive_PuzzleTwo_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle2.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTwo_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle2.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTwo_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle2.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Three
        if (GetSavedInt("TreeFive_PuzzleThree_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle3.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleThree_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle3.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleThree_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle3.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Four
        if (GetSavedInt("TreeFive_PuzzleFour_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle4.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleFour_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle4.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleFour_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle4.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Five
        if (GetSavedInt("TreeFive_PuzzleFive_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle5.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleFive_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle5.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleFive_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle5.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Six
        if (GetSavedInt("TreeFive_PuzzleSix_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle6.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleSix_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle6.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleSix_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle6.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Seven
        if (GetSavedInt("TreeFive_PuzzleSeven_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle7.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleSeven_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle7.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleSeven_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle7.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Eight
        if (GetSavedInt("TreeFive_PuzzleEight_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle8.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleEight_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle8.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleEight_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle8.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Nine
        if (GetSavedInt("TreeFive_PuzzleNine_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle9.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleNine_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle9.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleNine_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle9.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Ten
        if (GetSavedInt("TreeFive_PuzzleTen_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle10.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTen_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle10.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTen_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle10.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Eleven
        if (GetSavedInt("TreeFive_PuzzleEleven_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle11.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleEleven_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle11.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleEleven_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle11.GetComponent<Puzzle>().bronze = true;
        }

        //Puzzle Twelve
        if (GetSavedInt("TreeFive_PuzzleTwelve_Acorn") == 1)
        {
            GameState.Instance.tree5.puzzle12.GetComponent<Puzzle>().gold = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTwelve_Acorn") == 2)
        {
            GameState.Instance.tree5.puzzle12.GetComponent<Puzzle>().silver = true;
        }
        else if (GetSavedInt("TreeFive_PuzzleTwelve_Acorn") == 3)
        {
            GameState.Instance.tree5.puzzle12.GetComponent<Puzzle>().bronze = true;
        }
    }*/

    private void LoadNoOfAcornData()
    {
        if (GetSavedInt("TreeOne_NoOfGold") != null)
        {
            GameState.Instance.tree1.noOfGold = (int)GetSavedInt("TreeOne_NoOfGold");
        }
        if (GetSavedInt("TreeOne_NoOfSilver") != null)
        {
            GameState.Instance.tree1.noOfSilver = (int)GetSavedInt("TreeOne_NoOfSilver");
        }
        if (GetSavedInt("TreeOne_NoOfBronze") != null)
        {
            GameState.Instance.tree1.noOfBronze = (int)GetSavedInt("TreeOne_NoOfBronze");
        }

        if (GetSavedInt("TreeTwo_NoOfBronze") != null)
        {
            GameState.Instance.tree2.noOfBronze = (int)GetSavedInt("TreeTwo_NoOfBronze");
        }
        if (GetSavedInt("TreeTwo_NoOfSilver") != null)
        {
            GameState.Instance.tree2.noOfSilver = (int)GetSavedInt("TreeTwo_NoOfSilver");
        }
        if (GetSavedInt("TreeTwo_NoOfGold") != null)
        {
            GameState.Instance.tree2.noOfGold = (int)GetSavedInt("TreeTwo_NoOfGold");
        }

        if (GetSavedInt("TreeThree_NoOfGold") != null)
        {
            GameState.Instance.tree3.noOfGold = (int)GetSavedInt("TreeThree_NoOfGold");
        }
        if (GetSavedInt("TreeThree_NoOfSilver") != null)
        {
            GameState.Instance.tree3.noOfSilver = (int)GetSavedInt("TreeThree_NoOfSilver");
        }
        if (GetSavedInt("TreeThree_NoOfBronze") != null)
        {
            GameState.Instance.tree3.noOfBronze = (int)GetSavedInt("TreeThree_NoOfBronze");
        }

        if (GetSavedInt("TreeFour_NoOfGold") != null)
        {
            GameState.Instance.tree4.noOfGold = (int)GetSavedInt("TreeFour_NoOfGold");
        }
        if (GetSavedInt("TreeFour_NoOfSilver") != null)
        {
            GameState.Instance.tree4.noOfSilver = (int)GetSavedInt("TreeFour_NoOfSilver");
        }
        if (GetSavedInt("TreeFour_NoOfBronze") != null)
        {
            GameState.Instance.tree4.noOfBronze = (int)GetSavedInt("TreeFour_NoOfBronze");
        }

        if (GetSavedInt("TreeFive_NoOfGold") != null)
        {
            GameState.Instance.tree5.noOfGold = (int)GetSavedInt("TreeFive_NoOfGold");
        }
        if (GetSavedInt("TreeFive_NoOfSilver") != null)
        {
            GameState.Instance.tree5.noOfSilver = (int)GetSavedInt("TreeFive_NoOfSilver");
        }
        if (GetSavedInt("TreeFive_NoOfBronze") != null)
        {
            GameState.Instance.tree5.noOfBronze = (int)GetSavedInt("TreeFive_NoOfBronze");
        }
    }
}
