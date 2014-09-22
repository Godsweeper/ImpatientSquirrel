using UnityEngine;
using System.Collections;

//Functionality for moveable modular tile pieces
public class TouchTile : TouchableObject
{
    #region Public variables
    public Vector3 originalPos,         //The original position of the tile
                   originalScale;       //The original scale size of the tile
    public Vector2 originalGridPos,     //The original grid position at the start of the puzzle
                   swipeDifference,     //The difference between the start and end position of a swipe Input
                   swipeGridCheck;      //The grid position that will be checked after a swipe
    public float rowNo,                 //The grid row number within the puzzle
                 collumnNo;             //The grid collumn number within the puzzle
    public bool switchable,             //Check for if the tile is switchable with an empty tile
                vineBranch,             //Check for if the tiles branch is vines and cannot be moved
                //Height bools: false = low, true = high
                startHeight,            //The height position at the start of the tiles branch
                endHeight,              //The height position at the end of the tiles branch
                vertical,               //Check for if the branch is verticle or not
                verticalUpDown,         //Check for if the Squirrel is moving up or down on the tile /*Up = true, Down  = false*/
                verticalLeft,           //Check for if the Squirrel turns left or right when verticle 
                tileCheck,              //Check for if the tile has been selected
                breakable,              //Check for if the tile's branch is breakable
                moving,                 //Check for if the tile is moving
                squashing,              //Check for if the tile is squashing
                movingCheck,            //Bool used to make sure the moving check is done once
                gridNotSwapable;        //Check for if the grid position to be swaped to is viable    
    public TouchTile emptyTouchTile;    //Touchtile Instance for to replace the tile if it is breakable
    public int emptyNum;                //The number that the replacing empty tile in stored within the game manager 
	float myTimer = 1.5f;
	public int i = 0;
	public bool x = true;
    #endregion

	//public MyTouchLogic touchLogic;

    void Start()
    {
        //initialise original data at the start of a puzzle
        originalPos = this.transform.position;
        originalScale = this.transform.localScale;
        originalGridPos.x = collumnNo;
        originalGridPos.y = rowNo;   
		//touchLogic = GameObject.Find ("Gestures").GetComponent<MyTouchLogic> ();
    }


    void Update()
    {
        //If the tile is tweening(moving)
        if (LeanTween.isTweening(this.gameObject) == true)
        {
            //Do single moving check
            if (movingCheck == false)
            {
                //Tile is moving
                moving = true;
                movingCheck = true;
                //Debug.Log(this.gameObject.name + " is moving");
				FindPath.reset = true;
            }
        }
        //Else the tile is not moving
        else
        {
            moving = false;
            movingCheck = false;
        }
        //If the tile is squashing
        if (squashing == true)
        {
            //If the tile is not moving
            if (moving == false)
            {
                //Reset position and scale to original
                this.transform.position = originalPos;
                this.transform.localScale = originalScale;
                //Finish squashing
                squashing = false;
                
            }            
        }
		//Crystal nut has been activated
		if (CrystalNut.crystalActivated)
		{
			///run sequence for solving the particular puzzle.
			PuzzleAI.SolvePuzzle();

				while(i < PuzzleAI.puzzleSolution.Length && myTimer <= 0.0f && GameManager.Instance.gameStarted)
				{

				myTimer = GameManager.Instance.tileSwipeTime*4;

					if(this.collumnNo == PuzzleAI.collNoSolve[i] && this.rowNo == PuzzleAI.rowNumSolve[i])
					{
						if (PuzzleAI.puzzleSolution[i] == "left")
						{
							swipeGridCheck = new Vector2(collumnNo - 1, rowNo);
							//Check the grid for a viable swap
							GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
						}
						if (PuzzleAI.puzzleSolution[i] == "right")
						{
							swipeGridCheck = new Vector2(collumnNo + 1, rowNo);
							//Check the grid for a viable swap
							GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
						}
						if (PuzzleAI.puzzleSolution[i] == "up")
						{
							swipeGridCheck = new Vector2(collumnNo, rowNo - 1);
							//Check the grid for a viable swap
							GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
						}
						if (PuzzleAI.puzzleSolution[i] == "down")
						{
							swipeGridCheck = new Vector2(collumnNo, rowNo + 1);
							//Check the grid for a viable swap
							GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
						}
						if (PuzzleAI.puzzleSolution[i] == "wait")
						{
							myTimer = GameManager.Instance.tileSwipeTime*8;
						}
					}
					i++;//increments all pieces
					}
			if (GameManager.Instance.gameEnd)
			{
				i = 0;
				CrystalNut.crystalActivated = false;
			}
		}
	
		myTimer -= Time.deltaTime;

			
    }

	//Check for another object(squirrel) that has entered the tile
    void OnTriggerEnter(Collider coll)
    {
        //If the player collides with the tile
        if (coll.tag == "Player")
        {

            //If the tile is not switchable
            if (!switchable)
			{
                //Set the squirrels parent to this tile in the hierarchy 
                GameManager.Instance.Squirrel.parent = this.transform;
            }
            //Else if the tile is switchable
            else
            {
                //Make the squirrel have no parent
                GameManager.Instance.Squirrel.parent = null;
            }
        }
    }
 
    //Function to call when the squirrel stays inside the branch of this tile
    public void TriggerStay(Collider2D coll)
    {
        //If the player collides with the tile
        if (coll.tag == "Player")
        {
            //If the tile is not switchable
            if (!switchable)
            {
                //Set the squirrels parent to this tile in the hierarchy 
                GameManager.Instance.Squirrel.parent = this.transform;       
                //If there is no current tile selected and this tile has not been selected
                if (GameManager.Instance.currentTileSelected == false && this.tileCheck == false)
                {
                    //Set this tile to be the current tile
                    GameManager.Instance.currentTile = this;
                    GameManager.Instance.currentTileSelected = true;
                    this.tileCheck = true;
                }
                //Else If there is a current tile selected and not a next tile seleced and this tile still hasnt been selected
                else if (GameManager.Instance.nextTileSelected == false && this.tileCheck == false)
                {
                    //set this tile to be the next tile
                    GameManager.Instance.nextTile = this;
                    GameManager.Instance.nextTileSelected = true;
                    this.tileCheck = true;
                }

                //If a next tile has been selected
                if (GameManager.Instance.nextTileSelected == true)
                {
                    //If check for the next tile instance
                    if (GameManager.Instance.nextTile != null)
                    {
                        //CHANGE LATER
                        //If the current and next tiles are not vertical tiles
                        if (GameManager.Instance.currentTile.vertical != true && GameManager.Instance.nextTile.vertical != true)
                        {
                            //If the current end height is high and the next start height is low
                            if (GameManager.Instance.currentTile.endHeight == true && GameManager.Instance.nextTile.startHeight == false)
                            {
                                //Call for a Height death of the squirrel
                                HeightDeath();
                            }
                            //Else if the next tile is a row or more below the current tile
                            else if (GameManager.Instance.currentTile.rowNo < GameManager.Instance.nextTile.rowNo)
                            {
                                //Call for a Height death of the squirrel
                                HeightDeath();
                            }
                            else
                            {
                                //Call for a Non Height death 
                                NonHeightDeath();
                            }
                        }
                    }
                }
            }
            //Else if the tile is switchable
            else
            {
                //Make the squirrel have no parent
                GameManager.Instance.Squirrel.parent = null;
            }
        }
    }

    //Function to set up for the next tile check without causing height death
    private static void NonHeightDeath()
    {
        GameManager.Instance.currentTile = GameManager.Instance.nextTile;
        GameManager.Instance.nextTile = null;
        GameManager.Instance.nextTileSelected = false;
        GameManager.Instance.heightDeath = false;
    }

    //Function to set up for the next tile check and causes height death
    private static void HeightDeath()
    {
        Debug.Log("Height Death");
        GameManager.Instance.currentTile = GameManager.Instance.nextTile;
        GameManager.Instance.nextTile = null;
        GameManager.Instance.nextTileSelected = false;
        GameManager.Instance.heightDeath = true;
    }
    
    //Function to break this tile and replace it with its empty tile
    public void BreakTile()
    {
        //If the tile is breakable
        if (this.breakable == true)
        {
            //Swap this tile's empty tile's data to with this tile's data
            emptyTouchTile.transform.position = this.transform.position;
            emptyTouchTile.rowNo = this.rowNo;
            emptyTouchTile.collumnNo = this.collumnNo;
            emptyTouchTile.originalGridPos = this.originalGridPos;
            emptyTouchTile.originalPos = this.originalPos;
            //Swap this tile with it's empty tile in the game manager
            GameManager.Instance.SwapEmptyTile(this, emptyNum);
            //Remove this tile from the scene
            this.gameObject.SetActive(false);
            //Log debug message
            //Debug.Log("Tile Broken: " + this.name);
        }
        else
        {
            //Log debug message
            //Debug.Log("Tile not breakable" + this.name);
        }
    }    

    //Function to override the Swipe effect functionality of the touchable object's Swipe effect
    public override void SwipeEffect(FingerGestures.SwipeDirection direction, SwipeGesture gesture)
    {
        //Set up the Swipe grid check based on direction of the swipe
        #region Non-Diagonal Swipe Checks
		if (direction == FingerGestures.SwipeDirection.Right)
        {
            //Debug.Log("Swiped Right" + this.transform.name);
            swipeGridCheck = new Vector2(collumnNo + 1, rowNo);
        }
        else if (direction == FingerGestures.SwipeDirection.Left)
        {
            //Debug.Log("Swiped Left" + this.transform.name);
            swipeGridCheck = new Vector2(collumnNo - 1, rowNo);
        }
        else if (direction == FingerGestures.SwipeDirection.Up)
        {
            //Debug.Log("Swiped Up" + this.transform.name);
            swipeGridCheck = new Vector2(collumnNo, rowNo - 1);
        }
        else if (direction == FingerGestures.SwipeDirection.Down)
        {
            //Debug.Log("Swiped Down" + this.transform.name);
            swipeGridCheck = new Vector2(collumnNo, rowNo + 1);
        }
        #endregion
        #region Diagonal Swipe Checks
        //Else If the direction of the Swipe is not exact (Not: up, down, left or right) 
        else 
        {
            //Calculate the difference between the start and end positions of the swipe Input
            CalculateSwipeDifference(gesture);

            //Set up the Swipe grid check based on direction of the swipe
            
            if (direction == FingerGestures.SwipeDirection.LowerLeftDiagonal)
            {
                //Debug.Log("Swiped Lower Left" + this.transform.name);
                if (swipeDifference.x > swipeDifference.y)
                {
                    swipeGridCheck = new Vector2(collumnNo - 1, rowNo);
                }
                else
                {
                    swipeGridCheck = new Vector2(collumnNo, rowNo + 1);
                }
            }
            else if (direction == FingerGestures.SwipeDirection.UpperLeftDiagonal)
            {
                //Debug.Log("Swiped Upper Left" + this.transform.name);                
                if (swipeDifference.x > swipeDifference.y)
                {
                    swipeGridCheck = new Vector2(collumnNo - 1, rowNo);
                }
                else
                {
                    swipeGridCheck = new Vector2(collumnNo, rowNo - 1);
                }
            }
            else if (direction == FingerGestures.SwipeDirection.LowerRightDiagonal)
            {
                //Debug.Log("Swiped Lower Right" + this.transform.name);               
                if (swipeDifference.x > swipeDifference.y)
                {
                    swipeGridCheck = new Vector2(collumnNo + 1, rowNo);
                }
                else
                {
                    swipeGridCheck = new Vector2(collumnNo, rowNo + 1);
                }
            }
            else if (direction == FingerGestures.SwipeDirection.UpperRightDiagonal)
            {
                //Debug.Log("Swiped Upper Right" + this.transform.name);
                if (swipeDifference.x > swipeDifference.y)
                {
                    swipeGridCheck = new Vector2(collumnNo + 1, rowNo);
                }
                else
                {
                    swipeGridCheck = new Vector2(collumnNo, rowNo - 1);
                }
            }

        }
        #endregion
        //Check the grid for a viable swap
        GameManager.Instance.GridCheckSwap(swipeGridCheck, this);
        //Check the grid for a viable squash
        GameManager.Instance.GridCheckSquash(this);     
    }

    //Function to calculate the difference between a swipes start and end position
    private void CalculateSwipeDifference(SwipeGesture gesture)
    {
        swipeDifference.x = Mathf.Abs(Utility.Instance.GetWorldPos(gesture.StartPosition).x - Utility.Instance.GetWorldPos(gesture.Position).x);
        swipeDifference.y = Mathf.Abs(Utility.Instance.GetWorldPos(gesture.StartPosition).y - Utility.Instance.GetWorldPos(gesture.Position).y);
    }
}
