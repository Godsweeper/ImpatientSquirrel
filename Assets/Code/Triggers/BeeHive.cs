using UnityEngine;
using System.Collections;

public class BeeHive : MonoBehaviour 
{
    public bool falling,            //Check for if the Hive is falling
                dead;               //Check for if the Hive is dead
    public Transform brokenHive,    //Transform Instance for the Broken Hive 
                     beeSwarm;      //Transform Instance for the Bee Swarm

    void Update()
    {
        //if hive is falling 
        if (falling == true)
        {
            //Then the hive is no longer kinematic
            transform.parent.rigidbody2D.isKinematic = false;
        }
        else
        {
            //The Hive is Kinematic if not falling
            transform.parent.rigidbody2D.isKinematic = true;
        }

        //If the Hive dies
        if(dead == true)
        {
            //The Hive becomes Kinematic
            transform.parent.rigidbody2D.isKinematic = true;
            //And dissapears from the scene
            transform.parent.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //If the collider is a Branch
        if(coll.tag == "Branch")
        {
            //Create Local trigger tile
            TouchTile triggerTile;
            //Initiate the trigger tile
            triggerTile = coll.transform.parent.GetComponent<TouchTile>();
            //checks if the tile is breakable and will break if so
            triggerTile.BreakTile();
            //If trigger tile is breakable
            if (triggerTile.breakable == false)
            {
                //And not switchable
                if (triggerTile.switchable == false)
                {
                    //The Hives parent becomes the trigger tile
                    this.transform.parent.parent = coll.transform.parent;

                }
                //If the Hive is falling
                if (falling == true)
                {
                    //set falling to false
                    falling = false;
                    //Set up Broken Bee Hive on collided branch
                    transform.parent.rigidbody2D.isKinematic = true;
                    brokenHive.gameObject.SetActive(true);
                    beeSwarm.gameObject.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        //Create Local trigger tile
        TouchTile triggerTile;
        //If a Branch is colliding
        if (coll.tag == "Branch")
        {
            //Initiate the trigger tile
            triggerTile = coll.transform.parent.GetComponent<TouchTile>();
            //If the trigger tile is not moving
            if (triggerTile.moving == false)
            {
                //Set the Parent of the Hive to Null
                this.transform.parent.parent = null;
            }
        }
    }

}
