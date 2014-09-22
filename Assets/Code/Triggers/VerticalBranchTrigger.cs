using UnityEngine;
using System.Collections;

public class VerticalBranchTrigger : Trigger 
{
    public TouchTile parentTile; //Parent Touch tile Instance

    void Start() 
    {
       //Intialise the parent tile
       parentTile = transform.parent.parent.GetComponent<TouchTile>();
    }

    //Vertical Branch Trigger functionality
    public override void TriggerEffect(Collider2D coll)
    {
        //Trigger check
        if (triggerEntered == false)
        {
            //If the squirrel is sapped
            if (GameManager.Instance.sqrlCtrl.sapped == true)
            {
                print(coll.tag + " Hit: Vertical Branch Trigger");
                //If the squirrel is not moving vertically
                if (GameManager.Instance.movingVertical == false)
                {
                    //Set the squirrels gravity to 0%
                    GameManager.Instance.sqrlCtrl.rigidbody2D.gravityScale = 0.0f;
                    //If the tile forces movement upwards
                    if (parentTile.verticalUpDown == true)
                    {
                        //Set Squirrel to moving Up
                        GameManager.Instance.movingUpDown = true;
                    }
                    //Else if the tile forces movement downwards
                    else
                    {
                        //set Squirrel to moving Down
                        GameManager.Instance.movingUpDown = false;
                    }

                    //If the Squirrel is moving Up
                    if (GameManager.Instance.movingUpDown == true)
                    {
                        //Rotate the squirrel to allow upwards vertical movement
                        LeanTween.rotate(GameManager.Instance.Squirrel.gameObject, new Vector3(0f, 0f, 90.0f), 0.3f);
                    }
                    //Set Squirrel to moving verticle
                    GameManager.Instance.movingVertical = true;
                    //Finish trigger check
                    triggerEntered = true;
                }
                //Else if the squirrel is already vertical
                else
                {
                    print("already vertical");
                    //Set the squirrels gravity to 100%
                    GameManager.Instance.sqrlCtrl.rigidbody2D.gravityScale = 1.0f;
                    //If the parent tile forces movement to the left
                    if (parentTile.verticalLeft)
                    {
                        //Rotate the squirrel to allow movement to the left
                        LeanTween.rotate(GameManager.Instance.Squirrel.gameObject, new Vector3(0f, 0f, 320.0f), 0.3f);
                    }
                    //Set the squirrel to not moving vertically
                    GameManager.Instance.movingVertical = false;
                    //Finish trigger check
                    triggerEntered = true;
                }
            }
        }
    }
}
