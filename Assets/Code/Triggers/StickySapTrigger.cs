using UnityEngine;
using System.Collections;

public class StickySapTrigger : Trigger 
{

	//Sticky Sap Trigger functionality
    public override void TriggerEffect(Collider2D coll)
    {
        //Trigger enter check
        if (triggerEntered == false)
        {
            //Set the squirrel to be sapped
            GameManager.Instance.sqrlCtrl.sapped = true;
            //Reduce the speed of the squirrel by 30%
            GameManager.Instance.sqrlCtrl.Speed = (GameManager.Instance.sqrlCtrl.Speed / 100) * 70;
            //Call base functionality
            base.TriggerEffect(coll);
        }
    }
}
