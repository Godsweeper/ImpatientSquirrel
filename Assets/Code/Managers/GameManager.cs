using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager> 
{
    #region Variables
    public Transform Squirrel;
    public SquirrelController sqrlCtrl;
    public float startTime, gameTime;
    public float seconds, ms;
    public TouchTile currentTile, nextTile;
    public bool currentTileSelected, nextTileSelected, heightDeath, gameStarted, timeCheck, startTimeRecorded;
    public string gameTimeString, sucessTimeCaption;
    public Vector2 firstObjectGridPos, secondObjectGridPos;
    public Vector3 firstObjectPos;
    public Transform firstObject, secondObject;
    public bool firstTouch, gameEnd, paused, tilePickedup;
    public int startSecond, startMilisecond,miliSecond, second;
    public Timer gameStartTimer;
    public Transform oneOne, oneTwo, oneThree, oneFour,
                     twoOne, twoTwo, twoThree, twoFour,
                     threeOne, threeTwo, threeThree, threeFour,
                     tempTileTrans;
    public TouchTile oneOneTT, oneTwoTT, oneThreeTT, oneFourTT,
                     twoOneTT, twoTwoTT, twoThreeTT, twoFourTT,
                     threeOneTT, threeTwoTT, threeThreeTT, threeFourTT,
                     tempTT;
    public Transform emptyOne, emptyTwo, emptyThree, emptyFour, emptyFive, emptySix, emptySeven, emptyEight;
    public TouchTile emptyOneTT, emptyTwoTT, emptyThreeTT, emptyFourTT, emptyFiveTT, emptySixTT, emptySevenTT, emptyEightTT;
    public float tileThreasholdX, tileThreasholdY, tileSwipeTime, rottenFallTime;
    public Vector2 squashDistance2x3, squashDistance2x4, squashDistance3x3, squashDistance3x4;

    public bool tutorialFinished, timeSlowed, movingVertical, movingUpDown;

    #endregion

    void Awake()
    {       
        //Initiate start time 
        startTime = Time.time;
        Debug.Log("Start Time: " + startTime);   
    }

	// Use this for initialization
	void Start () 
    {
		tileSwipeTime = tileSwipeTime / 2;
        //Intiate game start variables
        timeSlowed = false;
	//	puzzleAI = false;
        sqrlCtrl = Squirrel.GetComponent<SquirrelController>();
        gameStartTimer = new Timer();
        gameStartTimer.setTimer(2);
        firstTouch = false;
        gameEnd = false;

        //Initiate Tiles at start of Puzzle
        if(oneOne != null)
            oneOneTT = oneOne.GetComponent<TouchTile>();

        if (oneTwo != null)
            oneTwoTT = oneTwo.GetComponent<TouchTile>();

        if (oneThree != null)
            oneThreeTT = oneThree.GetComponent<TouchTile>();

        if (oneFour != null)
            oneFourTT = oneFour.GetComponent<TouchTile>();

        if (twoOne != null)
            twoOneTT = twoOne.GetComponent<TouchTile>();

        if (twoTwo != null)
            twoTwoTT = twoTwo.GetComponent<TouchTile>();

        if (twoThree != null)
            twoThreeTT = twoThree.GetComponent<TouchTile>();

        if (twoFour != null)
            twoFourTT = twoFour.GetComponent<TouchTile>();

        if (threeOne != null)
            threeOneTT = threeOne.GetComponent<TouchTile>();

        if (threeTwo != null)
            threeTwoTT = threeTwo.GetComponent<TouchTile>();

        if (threeThree != null)
            threeThreeTT = threeThree.GetComponent<TouchTile>();

        if (threeFour != null)
            threeFourTT = threeFour.GetComponent<TouchTile>();
	}
	
	void FixedUpdate () 
    {
        if (tutorialFinished || GameState.Instance.currentPuzzle.tutorial == false || GameState.Instance.currentPuzzle.completed == true)
        {
            gameStartTimer.startTimer();
            gameStartTimer.UpdateTimer();
            timeCheck = gameStartTimer.checkTimer();
            if (timeCheck)
            {
                gameStarted = true;
            }
            if (gameStarted == true && startTimeRecorded == false)
            {
                startTime = Time.time;
                startTimeRecorded = true;
                Debug.Log("Start Time: " + startTime);
            }
            if (gameStarted && !paused && !gameEnd)
            {
                gameTime = Time.time - startTime;
                ms = (gameTime * 1000) % 1000;
                gameTimeString = string.Format("{0:00} : {1:000}", Mathf.Floor(gameTime), Mathf.Floor(ms));
            }
        }
	}

    //Check if the swipe on the grid requires a squash in a certain direction
    public void GridCheckSquash(TouchTile tile)
    {
        //If the tile is not swappable
        if (tile.gridNotSwapable == true)
        {
            //If the swipe was in the right direction
            if (tile.swipeGridCheck.x == tile.collumnNo + 1)
            {
                Debug.Log("Right");
                //Squash tile is right direction
                LeanTween.scaleX(tile.gameObject, (tile.transform.localScale.x / 100f) * 80f, tileSwipeTime);
                if (GameState.Instance.currentPuzzle.puzzleGridSize.y == 2)
                {
                    if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 3)
                    {
                        LeanTween.moveX(tile.gameObject, tile.transform.position.x + squashDistance2x3.x, tileSwipeTime);
                    }
                    else if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4)
                    {
                        LeanTween.moveX(tile.gameObject, tile.transform.position.x + squashDistance2x4.x, tileSwipeTime);
                    }
                }
                else if (GameState.Instance.currentPuzzle.puzzleGridSize.y == 3)
                {
                    if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 3)
                    {
                        LeanTween.moveX(tile.gameObject, tile.transform.position.x + squashDistance3x3.x, tileSwipeTime);
                    }
                    else if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4)
                    {
                        LeanTween.moveX(tile.gameObject, tile.transform.position.x + squashDistance3x4.x, tileSwipeTime);
                    }
                }
                tile.squashing = true;
            }
            //Else if the swipe was in the left direction
            else if (tile.swipeGridCheck.x == tile.collumnNo - 1)
            {
                Debug.Log("Left");
                //Squash tile in the left direction
                LeanTween.scaleX(tile.gameObject, (tile.transform.localScale.x / 100f) * 80f, tileSwipeTime);
                tile.squashing = true;
            }
            //Else if the swipe was in the downwards direction
            else if (tile.swipeGridCheck.y == tile.rowNo + 1)
            {
                Debug.Log("Down");
                //Squash the tile in the downwards direction
                LeanTween.scaleY(tile.gameObject, (tile.transform.localScale.y / 100f) * 80f, tileSwipeTime);
                if (GameState.Instance.currentPuzzle.puzzleGridSize.y == 2)
                {
                    if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 3)
                    {
                        LeanTween.moveY(tile.gameObject, tile.transform.position.y - squashDistance2x3.y, tileSwipeTime);
                    }
                    else if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4)
                    {
                        LeanTween.moveY(tile.gameObject, tile.transform.position.y - squashDistance2x4.y, tileSwipeTime);
                    }
                }
                else if (GameState.Instance.currentPuzzle.puzzleGridSize.y == 3)
                {
                    if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 3)
                    {
                        LeanTween.moveY(tile.gameObject, tile.transform.position.y - squashDistance3x3.y, tileSwipeTime);
                    }
                    else if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4)
                    {
                        LeanTween.moveY(tile.gameObject, tile.transform.position.y - squashDistance3x4.y, tileSwipeTime);
                    }
                }
                tile.squashing = true;
            }
            //Else if the swipe was in the Upwards direction
            else if (tile.swipeGridCheck.y == tile.rowNo - 1)
            {
                Debug.Log("Up");
                //Squash tile in the upwards direction
                LeanTween.scaleY(tile.gameObject, (tile.transform.localScale.y / 100f) * 80f, tileSwipeTime);
                tile.squashing = true;
            }
        }
    }

    //Check if the swipe on the grid requires a tile swap
    public void GridCheckSwap(Vector2 gridCheck, TouchTile tile)
    {
        if (tile.vineBranch == false)
        {
            //If the puzzle grid height is 3
            if (GameState.Instance.currentPuzzle.puzzleGridSize.y == 3 && gridCheck.y == 3)
            {
                //If the puzzle grid width is 4
                if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4 && gridCheck.x == 4)
                {
                    //GRID CHECK SPECIFIC FOR 3x4 GRIDS
                    if (gridCheck.x == 4 && gridCheck.y == 3)
                    {
                        if (threeFourTT.switchable == true)
                        {
                            SwapTiles(threeFour, threeFourTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                }
                else if (gridCheck.x < 4)
                {
                    //GRID CHECKS SPECIFIC FOR 3X3 GRIDS
                    if (gridCheck.x == 1 && gridCheck.y == 3)
                    {

                        if (threeOneTT.switchable == true)
                        {
                            SwapTiles(threeOne, threeOneTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 2 && gridCheck.y == 3)
                    {
                        if (threeTwoTT.switchable == true)
                        {
                            SwapTiles(threeTwo, threeTwoTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 3 && gridCheck.y == 3)
                    {
                        if (threeThreeTT.switchable == true)
                        {
                            SwapTiles(threeThree, threeThreeTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                }
            }
            else if (gridCheck.y < 3)
            {
                //If the puzzle grid width is 4
                if (GameState.Instance.currentPuzzle.puzzleGridSize.x == 4 && gridCheck.x == 4)
                {
                    //GRID CHECKS FOR x4 GRIDS
                    if (gridCheck.x == 4 && gridCheck.y == 1)
                    {
                        if (oneFourTT.switchable == true)
                        {
                            SwapTiles(oneFour, oneFourTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 4 && gridCheck.y == 2)
                    {
                        if (twoFourTT.switchable == true)
                        {
                            SwapTiles(twoFour, twoFourTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                }
                else if (gridCheck.x < 4)
                {
                    //GRID CHECKS FOR ALL GRIDS
                    if (gridCheck.x == 1 && gridCheck.y == 1)
                    {
                        if (oneOneTT.switchable == true)
                        {
                            SwapTiles(oneOne, oneOneTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 2 && gridCheck.y == 1)
                    {
                        if (oneTwoTT.switchable == true)
                        {
                            SwapTiles(oneTwo, oneTwoTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 3 && gridCheck.y == 1)
                    {
                        if (oneThreeTT.switchable == true)
                        {
                            SwapTiles(oneThree, oneThreeTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }

                    else if (gridCheck.x == 1 && gridCheck.y == 2)
                    {
                        if (twoOneTT.switchable == true)
                        {
                            Debug.Log("Tile is switchable");
                            SwapTiles(twoOne, twoOneTT, tile);
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            Debug.Log("Tile is not switchable");
                            tile.gridNotSwapable = true;
                        }
                    }
                    else if (gridCheck.x == 2 && gridCheck.y == 2)
                    {
                        if (twoTwoTT.switchable == true)
                        {
                            Debug.Log("Tile is switchable");
                            SwapTiles(twoTwo, twoTwoTT, tile);
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    else if (gridCheck.x == 3 && gridCheck.y == 2)
                    {
                        if (twoThreeTT.switchable == true)
                        {
                            SwapTiles(twoThree, twoThreeTT, tile);
                            Debug.Log("Tile is switchable");
                            tile.gridNotSwapable = false;
                        }
                        else
                        {
                            tile.gridNotSwapable = true;
                            Debug.Log("Tile is not switchable");
                        }
                    }
                    //END OF GRID CHECKS
                }
            }
        }
        else
        {
            tile.gridNotSwapable = true;
        }
    }

    //Swap Tiles based on position
    private void SwapTiles(Transform swapTrans, TouchTile swapTT, TouchTile tile)
    {
        //swapping positions
        tile.moving = true;
        if (timeSlowed == true)
        {
            LeanTween.move(tile.gameObject, swapTT.originalPos, (tileSwipeTime / 2));
        }
        else
        {
            LeanTween.move(tile.gameObject, swapTT.originalPos, tileSwipeTime);
        }

        swapTrans.position = tile.originalPos;

        //resetinng positions
        tile.originalPos = swapTT.originalPos;
        swapTT.originalPos = swapTrans.position;

        ReplaceManagerTiles(swapTT, tile);

        //swapping grid positions
        tile.collumnNo = swapTT.originalGridPos.x;
        tile.rowNo = swapTT.originalGridPos.y;
        swapTT.collumnNo = tile.originalGridPos.x;
        swapTT.rowNo = tile.originalGridPos.y;

        //resetting grid positions
        swapTT.originalGridPos.x = swapTT.collumnNo;
        swapTT.originalGridPos.y = swapTT.rowNo;
        tile.originalGridPos.x = tile.collumnNo;
        tile.originalGridPos.y = tile.rowNo;
    }

    //Replace the Tiles grid positions in the game manager
    private void ReplaceManagerTiles(TouchTile swapTT, TouchTile currTT)
    {
        if (currTT.collumnNo == 1 && currTT.rowNo == 1)
        {
            SwapPresetTilesOneOne(swapTT);
        }
        else if (currTT.collumnNo == 2 && currTT.rowNo == 1)
        {
            SwapPresetTilesOneTwo(swapTT);
        }
        else if (currTT.collumnNo == 3 && currTT.rowNo == 1)
        {
            SwapPresetTilesOneThree(swapTT);
        }
        else if (currTT.collumnNo == 4 && currTT.rowNo == 1)
        {
            SwapPresetTilesOneFour(swapTT);
        }
        else if (currTT.collumnNo == 1 && currTT.rowNo == 2)
        {
            SwapPresetTilesTwoOne(swapTT);
        }
        else if (currTT.collumnNo == 2 && currTT.rowNo == 2)
        {
            SwapPresetTilesTwoTwo(swapTT);
        }
        else if (currTT.collumnNo == 3 && currTT.rowNo == 2)
        {
            SwapPresetTilesTwoThree(swapTT);
        }
        else if (currTT.collumnNo == 4 && currTT.rowNo == 2)
        {
            SwapPresetTilesTwoFour(swapTT);
        }
        else if (currTT.collumnNo == 1 && currTT.rowNo == 3)
        {
            SwapPresetTilesThreeOne(swapTT);
        }
        else if (currTT.collumnNo == 2 && currTT.rowNo == 3)
        {
            SwapPresetTilesThreeTwo(swapTT);
        }
        else if (currTT.collumnNo == 3 && currTT.rowNo == 3)
        {
            SwapPresetTilesThreeThree(swapTT);
        }
        else if (currTT.collumnNo == 4 && currTT.rowNo == 3)
        {
            SwapPresetTilesThreeFour(swapTT);
        }
    }

    /*
     * ALL POSSIBLE CURRENT CODE COMBINATIONS ARE INSIDE FUNCTION "SwapPresetTilesOneOne(TouchTile swapTT)" (POSSIBLY COMMENTED OUT)
     * FOR FUTURE ADDITION IT WILL BE EASIER TO CREATE THE NEW CODE SECTIONS IN THIS FUNCTION AND THEN COPY, PASTE AND UPDATE AS REQUIRED
     */
    //Swap Manager tiles for grid position 1,1
    private void SwapPresetTilesOneOne(TouchTile swapTT)
    {
        /*
        //Swap tile oneOne
        if (swapTT.collumnNo == 1 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = oneOne;
            oneOneTT = oneOneTT;

            oneOne = tempTileTrans;
            oneOneTT = tempTT;
        }*/
        //Swap tile oneTwo
        if (swapTT.collumnNo == 2 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = oneTwo;
            oneOneTT = oneTwoTT;

            oneTwo = tempTileTrans;
            oneTwoTT = tempTT;
        }
        /*
        //Swap tile oneThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = oneThree;
            oneOneTT = oneThreeTT;

            oneThree = tempTileTrans;
            oneThreeTT = tempTT;
        }
        //Swap tile oneFour
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = oneFour;
            oneOneTT = oneFourTT;

            oneFour = tempTileTrans;
            oneFourTT = tempTT;
        }*/
        //Swap tile twoOne
        else if (swapTT.collumnNo == 1 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = twoOne;
            oneOneTT = twoOneTT;

            twoOne = tempTileTrans;
            twoOneTT = tempTT;
        }
        /*
        //Swap tile twoTwo
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = twoTwo;
            oneOneTT = twoTwoTT;

            twoTwo = tempTileTrans;
            twoTwoTT = tempTT;
        }
        //Swap tile twoThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = twoThree;
            oneOneTT = twoThreeTT;

            twoThree = tempTileTrans;
            twoThreeTT = tempTT;
        }
        //Swap tile twoFour
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = twoFour;
            oneOneTT = twoFourTT;

            twoFour = tempTileTrans;
            twoFourTT = tempTT;
        }
        //Swap tile threeOne
        else if (swapTT.collumnNo == 1 && swapTT.rowNo == 3)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = threeOne;
            oneOneTT = threeOneTT;

            threeOne = tempTileTrans;
            threeOneTT = tempTT;
        }
        //Swap tile threeTwo
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 3)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = threeTwo;
            oneOneTT = threeTwoTT;

            threeTwo = tempTileTrans;
            threeTwoTT = tempTT;
        }
        //Swap tile threeThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 3)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = threeThree;
            oneOneTT = threeThreeTT;

            threeThree = tempTileTrans;
            threeThreeTT = tempTT;
        }
        //Swap tile threeFour
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 3)
        {
            tempTileTrans = oneOne;
            tempTT = oneOneTT;

            oneOne = threeFour;
            oneOneTT = threeFourTT;

            threeFour = tempTileTrans;
            threeFourTT = tempTT;
        }*/
    }
    //Swap Manager tiles for grid position 1,2
    private void SwapPresetTilesOneTwo(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 1 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneTwo;
            tempTT = oneTwoTT;

            oneTwo = oneOne;
            oneTwoTT = oneOneTT;

            oneOne = tempTileTrans;
            oneOneTT = tempTT;
        }
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneTwo;
            tempTT = oneTwoTT;

            oneTwo = oneThree;
            oneTwoTT = oneThreeTT;

            oneThree = tempTileTrans;
            oneThreeTT = tempTT;
        }
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneTwo;
            tempTT = oneTwoTT;

            oneTwo = twoTwo;
            oneTwoTT = twoTwoTT;

            twoTwo = tempTileTrans;
            twoTwoTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 1,3
    private void SwapPresetTilesOneThree(TouchTile swapTT)
    {

        if (swapTT.collumnNo == 2 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneThree;
            tempTT = oneThreeTT;

            oneThree = oneTwo;
            oneThreeTT = oneTwoTT;

            oneTwo = tempTileTrans;
            oneTwoTT = tempTT;
        }
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneThree;
            tempTT = oneThreeTT;

            oneThree = oneFour;
            oneThreeTT = oneFourTT;

            oneFour = tempTileTrans;
            oneFourTT = tempTT;
        }
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneThree;
            tempTT = oneThreeTT;

            oneThree = twoThree;
            oneThreeTT = twoThreeTT;

            twoThree = tempTileTrans;
            twoThreeTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 1,4
    private void SwapPresetTilesOneFour(TouchTile swapTT)
    {

        if (swapTT.collumnNo == 3 && swapTT.rowNo == 1)
        {
            tempTileTrans = oneFour;
            tempTT = oneFourTT;

            oneFour = oneThree;
            oneFourTT = oneThreeTT;

            oneThree = tempTileTrans;
            oneThreeTT = tempTT;
        }
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 2)
        {
            tempTileTrans = oneFour;
            tempTT = oneFourTT;

            oneFour = twoFour;
            oneFourTT = twoFourTT;

            twoFour = tempTileTrans;
            twoFourTT = tempTT;
        }
    }

    //Swap Manager tiles for grid position 2,1
    private void SwapPresetTilesTwoOne(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 1 && swapTT.rowNo == 1)
        {
            tempTileTrans = twoOne;
            tempTT = twoOneTT;

            twoOne = oneOne;
            twoOneTT = oneOneTT;

            oneOne = tempTileTrans;
            oneOneTT = tempTT;
        }
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoOne;
            tempTT = twoOneTT;

            twoOne = twoTwo;
            twoOneTT = twoTwoTT;

            twoTwo = tempTileTrans;
            twoTwoTT = tempTT;
        }
        //Swap tile threeOne
        else if (swapTT.collumnNo == 1 && swapTT.rowNo == 3)
        {
            tempTileTrans = twoOne;
            tempTT = twoOneTT;

            twoOne = threeOne;
            twoOneTT = threeOneTT;

            threeOne = tempTileTrans;
            threeOneTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 2,2
    private void SwapPresetTilesTwoTwo(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 2 && swapTT.rowNo == 1)
        {
            tempTileTrans = twoTwo;
            tempTT = twoTwoTT;

            twoTwo = oneTwo;
            twoTwoTT = oneTwoTT;

            oneTwo = tempTileTrans;
            oneTwoTT = tempTT;
        }
        else if (swapTT.collumnNo == 1 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoTwo;
            tempTT = twoTwoTT;

            twoTwo = twoOne;
            twoTwoTT = twoOneTT;

            twoOne = tempTileTrans;
            twoOneTT = tempTT;
        }
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoTwo;
            tempTT = twoTwoTT;

            twoTwo = twoThree;
            twoTwoTT = twoThreeTT;

            twoThree = tempTileTrans;
            twoThreeTT = tempTT;
        }
        //Swap tile threeTwo
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 3)
        {
            tempTileTrans = twoTwo;
            tempTT = twoTwoTT;

            twoTwo = threeTwo;
            twoTwoTT = threeTwoTT;

            threeTwo = tempTileTrans;
            threeTwoTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 2,3
    private void SwapPresetTilesTwoThree(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 3 && swapTT.rowNo == 1)
        {
            tempTileTrans = twoThree;
            tempTT = twoThreeTT;

            twoThree = oneThree;
            twoThreeTT = oneThreeTT;

            oneThree = tempTileTrans;
            oneThreeTT = tempTT;
        }
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoThree;
            tempTT = twoThreeTT;

            twoThree = twoTwo;
            twoThreeTT = twoTwoTT;

            twoTwo = tempTileTrans;
            twoTwoTT = tempTT;
        }
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoThree;
            tempTT = twoThreeTT;

            twoThree = twoFour;
            twoThreeTT = twoFourTT;

            twoFour = tempTileTrans;
            twoFourTT = tempTT;
        }
        //Swap tile threeThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 3)
        {
            tempTileTrans = twoThree;
            tempTT = twoThreeTT;

            twoThree = threeThree;
            twoThreeTT = threeThreeTT;

            threeThree = tempTileTrans;
            threeThreeTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 2,4
    private void SwapPresetTilesTwoFour(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 4 && swapTT.rowNo == 1)
        {
            tempTileTrans = twoFour;
            tempTT = twoFourTT;

            twoFour = oneFour;
            twoFourTT = oneFourTT;

            oneFour = tempTileTrans;
            oneFourTT = tempTT;
        }
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 2)
        {
            tempTileTrans = twoFour;
            tempTT = twoFourTT;

            twoFour = twoThree;
            twoFourTT = twoThreeTT;

            twoThree = tempTileTrans;
            twoThreeTT = tempTT;
        }
        //Swap tile threeFour
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 3)
        {
            tempTileTrans = twoFour;
            tempTT = twoFourTT;

            twoFour = threeFour;
            twoFourTT = threeFourTT;

            threeFour = tempTileTrans;
            threeFourTT = tempTT;
        }
    }

    //Swap Manager tiles for grid position 3,1
    private void SwapPresetTilesThreeOne(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 1 && swapTT.rowNo == 2)
        {
            tempTileTrans = threeOne;
            tempTT = threeOneTT;

            threeOne = twoOne;
            threeOneTT = twoOneTT;

            twoOne = tempTileTrans;
            twoOneTT = tempTT;
        }
        //Swap tile threeTwo
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeOne;
            tempTT = threeOneTT;

            threeOne = threeTwo;
            threeOneTT = threeTwoTT;

            threeTwo = tempTileTrans;
            threeTwoTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 3,2
    private void SwapPresetTilesThreeTwo(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 2 && swapTT.rowNo == 2)
        {
            tempTileTrans = threeTwo;
            tempTT = threeTwoTT;

            threeTwo = twoTwo;
            threeTwoTT = twoTwoTT;

            twoTwo = tempTileTrans;
            twoTwoTT = tempTT;
        }
        //Swap tile threeOne
        else if (swapTT.collumnNo == 1 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeTwo;
            tempTT = threeTwoTT;

            threeTwo = threeOne;
            threeTwoTT = threeOneTT;

            threeOne = tempTileTrans;
            threeOneTT = tempTT;
        }
        //Swap tile threeThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeTwo;
            tempTT = threeTwoTT;

            threeTwo = threeThree;
            threeTwoTT = threeThreeTT;

            threeThree = tempTileTrans;
            threeThreeTT = tempTT;
        }
    }
    //Swap Manager tiles for grid position 3,3
    private void SwapPresetTilesThreeThree(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 3 && swapTT.rowNo == 2)
        {
            tempTileTrans = threeThree;
            tempTT = threeThreeTT;

            threeThree = twoThree;
            threeThreeTT = twoThreeTT;

            twoThree = tempTileTrans;
            twoThreeTT = tempTT;
        }
        //Swap tile threeTwo
        else if (swapTT.collumnNo == 2 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeThree;
            tempTT = threeThreeTT;

            threeThree = threeTwo;
            threeThreeTT = threeTwoTT;

            threeTwo = tempTileTrans;
            threeTwoTT = tempTT;
        }
        //Swap tile threeFour
        else if (swapTT.collumnNo == 4 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeThree;
            tempTT = threeThreeTT;

            threeThree = threeFour;
            threeThreeTT = threeFourTT;

            threeFour = tempTileTrans;
            threeFourTT = tempTT;
        }

    }
    //Swap Manager tiles for grid position 3,4
    private void SwapPresetTilesThreeFour(TouchTile swapTT)
    {
        if (swapTT.collumnNo == 4 && swapTT.rowNo == 2)
        {
            tempTileTrans = threeFour;
            tempTT = threeFourTT;

            threeFour = twoFour;
            threeFourTT = twoFourTT;

            twoFour = tempTileTrans;
            twoFourTT = tempTT;
        }
        //Swap tile threeThree
        else if (swapTT.collumnNo == 3 && swapTT.rowNo == 3)
        {
            tempTileTrans = threeFour;
            tempTT = threeFourTT;

            threeFour = threeThree;
            threeFourTT = threeThreeTT;

            threeThree = tempTileTrans;
            threeThreeTT = tempTT;
        }
    }

    //SWAP EMPTY TILES FOR BROKEN BRANCHES
    public void SwapEmptyTile(TouchTile swapTT, int emptyNum)
    {
        if (swapTT.rowNo == 1)
        {
            if (swapTT.collumnNo == 1)
            {
                ReplaceEmptyoneOne(emptyNum);
            }
            else if (swapTT.collumnNo == 2)
            {
                ReplaceEmptyoneTwo(emptyNum);
            }
            else if (swapTT.collumnNo == 3)
            {
                ReplaceEmptyoneThree(emptyNum);
            }
            else if (swapTT.collumnNo == 4)
            {
                ReplaceEmptyoneFour(emptyNum);
            }
        }
        else if (swapTT.rowNo == 2)
        {
            if (swapTT.collumnNo == 1)
            {
                ReplaceEmptytwoOne(emptyNum);
            }
            else if (swapTT.collumnNo == 2)
            {
                ReplaceEmptytwoTwo(emptyNum);
            }
            else if (swapTT.collumnNo == 3)
            {
                ReplaceEmptytwoThree(emptyNum);
            }
            else if (swapTT.collumnNo == 4)
            {
                ReplaceEmptytwoFour(emptyNum);
            }
        }
        else if (swapTT.rowNo == 3)
        {
            if (swapTT.collumnNo == 1)
            {
                ReplaceEmptythreeOne(emptyNum);
            }
            else if (swapTT.collumnNo == 2)
            {
                ReplaceEmptythreeTwo(emptyNum);
            }
            else if (swapTT.collumnNo == 3)
            {
                ReplaceEmptythreeThree(emptyNum);
            }
            else if (swapTT.collumnNo == 4)
            {
                ReplaceEmptythreeFour(emptyNum);
            }
        }
    }

    //Swap Manager tiles with empty replacement tile for grid position 1,1
    private void ReplaceEmptyoneOne(int emptyNum)
    {
        if (emptyNum == 1)
        {
            oneOne = emptyOne;
            oneOneTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            oneOne = emptyTwo;
            oneOneTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            oneOne = emptyThree;
            oneOneTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            oneOne = emptyFour;
            oneOneTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            oneOne = emptyFive;
            oneOneTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            oneOne = emptySix;
            oneOneTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            oneOne = emptySeven;
            oneOneTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            oneOne = emptyEight;
            oneOneTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 1,2
    private void ReplaceEmptyoneTwo(int emptyNum)
    {
        if (emptyNum == 1)
        {
            oneTwo = emptyOne;
            oneTwoTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            oneTwo = emptyTwo;
            oneTwoTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            oneTwo = emptyThree;
            oneTwoTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            oneTwo = emptyFour;
            oneTwoTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            oneTwo = emptyFive;
            oneTwoTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            oneTwo = emptySix;
            oneTwoTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            oneTwo = emptySeven;
            oneTwoTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            oneTwo = emptyEight;
            oneTwoTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 1,3
    private void ReplaceEmptyoneThree(int emptyNum)
    {
        if (emptyNum == 1)
        {
            oneThree = emptyOne;
            oneThreeTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            oneThree = emptyTwo;
            oneThreeTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            oneThree = emptyThree;
            oneThreeTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            oneThree = emptyFour;
            oneThreeTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            oneThree = emptyFive;
            oneThreeTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            oneThree = emptySix;
            oneThreeTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            oneThree = emptySeven;
            oneThreeTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            oneThree = emptyEight;
            oneThreeTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 1,4
    private void ReplaceEmptyoneFour(int emptyNum)
    {
        if (emptyNum == 1)
        {
            oneFour = emptyOne;
            oneFourTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            oneFour = emptyTwo;
            oneFourTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            oneFour = emptyThree;
            oneFourTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            oneFour = emptyFour;
            oneFourTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            oneFour = emptyFive;
            oneFourTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            oneFour = emptySix;
            oneFourTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            oneFour = emptySeven;
            oneFourTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            oneFour = emptyEight;
            oneFourTT = emptyEightTT;
        }
    }

    //Swap Manager tiles with empty replacement tile for grid position 2,1
    private void ReplaceEmptytwoOne(int emptyNum)
    {
        if (emptyNum == 1)
        {
            twoOne = emptyOne;
            twoOneTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            twoOne = emptyTwo;
            twoOneTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            twoOne = emptyThree;
            twoOneTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            twoOne = emptyFour;
            twoOneTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            twoOne = emptyFive;
            twoOneTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            twoOne = emptySix;
            twoOneTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            twoOne = emptySeven;
            twoOneTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            twoOne = emptyEight;
            twoOneTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 2,2
    private void ReplaceEmptytwoTwo(int emptyNum)
    {
        if (emptyNum == 1)
        {
            twoTwo = emptyOne;
            twoTwoTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            twoTwo = emptyTwo;
            twoTwoTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            twoTwo = emptyThree;
            twoTwoTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            twoTwo = emptyFour;
            twoTwoTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            twoTwo = emptyFive;
            twoTwoTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            twoTwo = emptySix;
            twoTwoTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            twoTwo = emptySeven;
            twoTwoTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            twoTwo = emptyEight;
            twoTwoTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 2,3
    private void ReplaceEmptytwoThree(int emptyNum)
    {
        if (emptyNum == 1)
        {
            twoThree = emptyOne;
            twoThreeTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            twoThree = emptyTwo;
            twoThreeTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            twoThree = emptyThree;
            twoThreeTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            twoThree = emptyFour;
            twoThreeTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            twoThree = emptyFive;
            twoThreeTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            twoThree = emptySix;
            twoThreeTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            twoThree = emptySeven;
            twoThreeTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            twoThree = emptyEight;
            twoThreeTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 2,4
    private void ReplaceEmptytwoFour(int emptyNum)
    {
        if (emptyNum == 1)
        {
            twoFour = emptyOne;
            twoFourTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            twoFour = emptyTwo;
            twoFourTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            twoFour = emptyThree;
            twoFourTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            twoFour = emptyFour;
            twoFourTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            twoFour = emptyFive;
            twoFourTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            twoFour = emptySix;
            twoFourTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            twoFour = emptySeven;
            twoFourTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            twoFour = emptyEight;
            twoFourTT = emptyEightTT;
        }
    }

    //Swap Manager tiles with empty replacement tile for grid position 3,1
    private void ReplaceEmptythreeOne(int emptyNum)
    {
        if (emptyNum == 1)
        {
            threeOne = emptyOne;
            threeOneTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            threeOne = emptyTwo;
            threeOneTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            threeOne = emptyThree;
            threeOneTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            threeOne = emptyFour;
            threeOneTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            threeOne = emptyFive;
            threeOneTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            threeOne = emptySix;
            threeOneTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            threeOne = emptySeven;
            threeOneTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            threeOne = emptyEight;
            threeOneTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 3,2
    private void ReplaceEmptythreeTwo(int emptyNum)
    {
        if (emptyNum == 1)
        {
            threeTwo = emptyOne;
            threeTwoTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            threeTwo = emptyTwo;
            threeTwoTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            threeTwo = emptyThree;
            threeTwoTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            threeTwo = emptyFour;
            twoTwoTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            threeTwo = emptyFive;
            threeTwoTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            threeTwo = emptySix;
            threeTwoTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            threeTwo = emptySeven;
            threeTwoTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            threeTwo = emptyEight;
            threeTwoTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 3,3
    private void ReplaceEmptythreeThree(int emptyNum)
    {
        if (emptyNum == 1)
        {
            threeThree = emptyOne;
            threeThreeTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            threeThree = emptyTwo;
            threeThreeTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            threeThree = emptyThree;
            threeThreeTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            threeThree = emptyFour;
            threeThreeTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            threeThree = emptyFive;
            threeThreeTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            threeThree = emptySix;
            threeThreeTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            threeThree = emptySeven;
            threeThreeTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            threeThree = emptyEight;
            threeThreeTT = emptyEightTT;
        }
    }
    //Swap Manager tiles with empty replacement tile for grid position 3,4
    private void ReplaceEmptythreeFour(int emptyNum)
    {
        if (emptyNum == 1)
        {
            threeFour = emptyOne;
            threeFourTT = emptyOneTT;
        }
        else if (emptyNum == 2)
        {
            threeFour = emptyTwo;
            threeFourTT = emptyTwoTT;
        }
        else if (emptyNum == 3)
        {
            threeFour = emptyThree;
            threeFourTT = emptyThreeTT;
        }
        else if (emptyNum == 4)
        {
            threeFour = emptyFour;
            threeFourTT = emptyFourTT;
        }
        else if (emptyNum == 5)
        {
            threeFour = emptyFive;
            threeFourTT = emptyFiveTT;
        }
        else if (emptyNum == 6)
        {
            threeFour = emptySix;
            threeFourTT = emptySixTT;
        }
        else if (emptyNum == 7)
        {
            threeFour = emptySeven;
            threeFourTT = emptySevenTT;
        }
        else if (emptyNum == 8)
        {
            threeFour = emptyEight;
            threeFourTT = emptyEightTT;
        }
    }
   
}
