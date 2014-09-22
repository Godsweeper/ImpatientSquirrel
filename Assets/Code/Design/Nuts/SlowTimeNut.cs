using UnityEngine;
using System.Collections;
//Extended Nut functionality for the Slow Time Nut
public class SlowTimeNut : NutItem
{
    //Overrided Nut effect function from base Nut Class
    public override void NutEffect()
    {
        //If the players inventory has atleast 1 nut available
        if (GameState.Instance.playerInventory.slowTimeNutCount > 0)
        {
            //Set the Timescale to 50%
            Time.timeScale = 0.5f;
            //Update the Fixed Delta Time to match the current Timescale
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            //Tell the Game Manager that the TimeScale has been slowed down
            GameManager.Instance.timeSlowed = true;
            //Remove a Slow Time Nut from the players Inventory
            GameState.Instance.playerInventory.slowTimeNutCount--;
        }
    }
}
