using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour 
{
    public bool triggerEntered = false, nonPlayerTriggerEntered = false; 

    //When the trigger is Entered
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Check if the character is the object that entered
        if (coll.tag == "Player")
        {
            //Do functionality
			TriggerEffect(coll);
        }
        else
        {
            NonPlayerTriggerEffect(coll);
        }
    }

	//When the trigger is Entered
	void OnTriggerStay2D(Collider2D coll)
	{
		//Check if the character is the object that entered
		if (coll.tag == "Player")
		{
			//Do functionality
			TriggerEffect(coll);
		}
		else
		{
			NonPlayerTriggerEffect(coll);
		}
	}

    //When the trigger is exited
    void OnTriggerExit2D(Collider2D coll)
    {
        //Check if the player is the object that entered
        if (coll.tag == "Player")
        {
            //Do functionality for player
            TriggerExitEffect(coll);
        }
        else
        {
            //Do functionality for non player
            NonPlayerTriggerExitEffect(coll);
        }
    }

    //Virtual trigger enter functionality
    public virtual void TriggerEffect(Collider2D coll)
    {

        triggerEntered = true;

    }

    //Virtual non player trigger enterfunctionality
    public virtual void NonPlayerTriggerEffect(Collider2D coll)
    {
        nonPlayerTriggerEntered = true;
    }

    //Virtual trigger exit functionality
    public virtual void TriggerExitEffect(Collider2D coll)
    {
        //triggerEntered = false;
    }

    //Virtual non player trigger exit functionality
    public virtual void NonPlayerTriggerExitEffect(Collider2D coll)
    {
        //nonPlayerTriggerEntered = false;
    }
}

