using UnityEngine;
using System.Collections;

public class TouchTileBranch : TouchableObject
{
    #region Public variables
    public bool branchEntered,          //Check for if the branch has been entered
                timeCheck,              //Check for the rotten branch timer's success
                triggerhit;             //Check for id the trigger has been hit already
    public Timer rottenTimer,           //Timer for the rotten branch components to start falling
                 breakTimer;            //Timer for the rotten branch's tile to break
    //Transforms for each rotten branch component
    public Transform rotten1, rotten2, rotten3, rotten4;
    #endregion

    #region Private Variables
    private float rottenTimePercent,    //1/4 of the rotten fall time 
                  rottenTime1,          //3/4 of the rotten fall time
                  rottenTime2,          //1/2 of the rotten fall time
                  rotten1YPos,          //Original Y position of the first branch component
                  rotten2YPos,          //Original Y position of the second branch component
                  rotten3YPos,          //Original Y position of the third branch component
                  rotten4YPos;          //Original Y position of the fourth branch component
    //The rigidbody instances of the branch components
    private Rigidbody2D rb1, rb2, rb3, rb4;
    private TouchTile parentTouchTile;  //The Touch tile that is the parent of this Branch
    #endregion

    void Start()
    {
        //Get the parent touch tile instance
        parentTouchTile = transform.parent.GetComponent<TouchTile>();
        //Intiate broken branch variables if the Tile is breakable
        if (parentTouchTile.breakable == true)
        {
            //Initialise the timers
            rottenTimer = new Timer();
            breakTimer = new Timer();
            //Set the timers
            rottenTimer.setTimer(GameManager.Instance.rottenFallTime);
            breakTimer.setTimer(0.4f);
            //gets 1/4 of the fall time
            rottenTimePercent = (GameManager.Instance.rottenFallTime / 4);
            //makes rottenTime1 3/4 of fall time
            rottenTime1 = GameManager.Instance.rottenFallTime - rottenTimePercent;
            //makes rottenTime2 1/2 of fall time
            rottenTime2 = GameManager.Instance.rottenFallTime - (rottenTimePercent * 2);

            //Set the Original Y positions of the branch componenents
            rotten1YPos = rotten1.localPosition.y;
            rotten2YPos = rotten2.localPosition.y;
            rotten3YPos = rotten3.localPosition.y;
            rotten4YPos = rotten4.localPosition.y;
            //Set the rigidbody's of the branch componenents
            rb1 = rotten1.rigidbody2D;
            rb2 = rotten2.rigidbody2D;
            rb3 = rotten3.rigidbody2D;
            rb4 = rotten4.rigidbody2D;            
        }
    }

    void Update()
    {
        //If the Parent Touch tile is breakable
        if(parentTouchTile.breakable == true)
        {
            //The branch componenets have been set up 
            if (rotten1 != null && rotten2 != null && rotten3 != null && rotten4 != null)
            {
                //If the branch has been entered by the squirrel
                if (this.branchEntered == true && GameManager.Instance.gameStarted)
                {
                    //Start the rotten timer
                    rottenTimer.startTimer();
                    //If the Parent touch tile is not moving
                    if (parentTouchTile.moving == false)
                    {
                        //Update the rotten timer
                        rottenTimer.UpdateTimer();
                    }
                    //Check if the rotten timer has been reduced to 0
                    timeCheck = rottenTimer.checkTimer();
                    //If the first branch componenet is ready to fall
                    if (rottenTimer.checkFullTimerNum() <= rottenTime1 && rottenTimer.checkFullTimerNum() > rottenTime2)
                    {
                        //Allow the first branch component to fall
                        rb1.rigidbody2D.isKinematic = false;
                        //If the first branch component has fallen far enough
                        if(rotten1.localPosition.y < rotten1YPos - 1)
                        {
                            //Fade away the branch component
                            rotten1.gameObject.SetActive(false);
                        }
                    }
                    //If the second branch componenet is ready to fall
                    if (rottenTimer.checkFullTimerNum() <= rottenTime2 && rottenTimer.checkFullTimerNum() > rottenTimePercent)
                    {
                        //Allow the second branch component to fall
                        rb2.rigidbody2D.isKinematic = false;
                        //If the second branch component has fallen far enough
                        if (rotten2.localPosition.y < rotten2YPos - 1)
                        {
                            //Fade away the branch component
                            rotten2.gameObject.SetActive(false);
                        }
                    }
                    //If the third branch componenet is ready to fall
                    if (rottenTimer.checkFullTimerNum() <= rottenTimePercent && rottenTimer.checkFullTimerNum() > 0.0f)
                    {
                        //Allow the third branch component to fall
                        rb3.rigidbody2D.isKinematic = false;
                        //If the third branch component has fallen far enough
                        if (rotten3.localPosition.y < rotten3YPos - 1)
                        {
                            //Fade away the branch component
                            rotten3.gameObject.SetActive(false);
                        }
                    }
                    //If the rotten timer has been reduced to 0
                    if (timeCheck)
                    {
                        //Allow the fourth branch component to fall
                        rb4.transform.rigidbody2D.isKinematic = false;
                        //Start the break timer
                        breakTimer.startTimer();
                        //If the parent tile is not moving
                        if (parentTouchTile.moving == false)
                        {
                            //Update the break timer
                            breakTimer.UpdateTimer();
                        }
                        //If the break timer has reached 0
                        if (breakTimer.checkTimer())
                        {
                            //Break the parent touch tile
                            parentTouchTile.BreakTile();
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {   
        //If the squirrel has collided with the trigger
        if(coll.tag =="Player" )
        {
            //Trigger hit check
            if (triggerhit == false)
            {
                //Debug.Log("Player hit branch: " + this.gameObject.name);
                //Set the branch to have been entered
                this.branchEntered = true;
                //If height death has been set to true and the parent touch tile is the currently active tile
                if (GameManager.Instance.heightDeath == true && parentTouchTile == GameManager.Instance.currentTile)
                {
                    //Set the death screen to start
                    GameManager.Instance.gameEnd = true;
                    GameState.Instance.deathMenu = true;                    
                }
                //Finish the tigger hit check
                triggerhit = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        //Call the parent touch tiles trigger stay function
        parentTouchTile.TriggerStay(coll);
        //If the squirrel has collided with the trigger
        if (coll.tag == "Player") 
        {
            //Set the branch to have been entered
            this.branchEntered = true;
            //Debug.Log("Player hit branch: " + this.gameObject.name);
            //If height death has been set to true and the parent touch tile is the currently active tile
            if (GameManager.Instance.heightDeath == true && parentTouchTile == GameManager.Instance.currentTile)
            {
                //Set the death screen to start
                GameManager.Instance.gameEnd = true;
                GameState.Instance.deathMenu = true;
            }     
        }
    }

    //Overriden Swipe effect of the Touchable object
    public override void SwipeEffect(FingerGestures.SwipeDirection direction, SwipeGesture gesture)
    {
        //Calls the parent Touch Tiles dwipe effect
        parentTouchTile.SwipeEffect(direction, gesture);
    }
}
