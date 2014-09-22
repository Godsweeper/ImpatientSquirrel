using UnityEngine;
using System.Collections;

public class DeathTrigger : Trigger
{
    //DeathTrigger functionality
    public override void TriggerEffect(Collider2D coll)
    {
        //If the game hasnt ended
        if(GameManager.Instance.gameEnd == false)
        {
            print(coll.tag + " Hit: Death Trigger");
            //Set up the Death Menu screen
            GameManager.Instance.gameEnd = true;
            GameState.Instance.deathMenu = true;
            //Call base functionality
            base.TriggerEffect(coll);
        }
    }

    //DeathTrigger non-player functionality
    public override void NonPlayerTriggerEffect(Collider2D coll)
    {
        print(coll.tag + " Hit: Death Trigger");
        //If the collider is a Hive
        if(coll.tag == "Hive")
        {
            //Kill the Hive!
            coll.gameObject.GetComponent<BeeHive>().dead = true;
        }
        //Else if the collider is a branc component
        else if(coll.tag == "BranchComp")
        {
            //Delete the branch component
            coll.gameObject.SetActive(false);
        }
        //Call base functionality
        base.NonPlayerTriggerEffect(coll);
    }
}
