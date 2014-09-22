using UnityEngine;
using System.Collections;

public class BeeHiveTrigger : Trigger 
{
    public BeeHive hive; //Bee Hive Instance
    //Bee Hive Trigger functionality
    public override void TriggerEffect(Collider2D coll)
    {
        //Trigger check
        if (triggerEntered == false)
        {
            print(coll.tag + " Hit: Bee Hive Trigger");
            //Make the Hive start to fall
            hive.falling = true;
            triggerEntered = true;
        }
    }


}
