using UnityEngine;
using System.Collections;

//Extended Nut functionality for the Crystal Nut
public class CrystalNut : NutItem 
{
	public static bool crystalActivated;
	public void Awake()
	{

		crystalActivated = false;
		//Debug.Log ("Awake is here!");

	}
    //Overriden Nut effect function from base Nut Class
    public override void NutEffect()
    {

		//if (GameState.Instance.playerInventory.crystalNutCount> 0)
		//{
		crystalActivated = true;
		GameState.Instance.startScene(GameState.Instance.currentScene); 
		//Remove a Crystal Nut from the players Inventory
		//GameState.Instance.playerInventory.crystalNutCount--;
		//}

    }
	
}
