using UnityEngine;
using System.Collections;

public class NutInventory : MonoSingleton<NutInventory> 
{
    /*NUT TYPES
     * 1 = Crystal Nut
     * 2 = Rewind Nut
     * 3 = Slow Time Nut
     */
    #region Public variables
    //Nut Counts
    public int crystalNutCount, rewindNutCount, slowTimeNutCount;
    //Nut Items
    public NutItem crystalNut, rewindNut, slowTimeNut;
    #endregion

    //Function for when a player buys a Nut Item
    public void BuyNut(int nutType, int amount)
    {
        if(nutType == 1)
        {
            crystalNutCount = crystalNutCount + amount;
        }
        if (nutType == 2)
        {
            rewindNutCount = rewindNutCount + amount;
        }
        if (nutType == 3)
        {
            slowTimeNutCount = slowTimeNutCount + amount;
        }
    }

    //Function to get the but count based on the nut type
    public int GetNutAmount(int nutType)
    {
        if (nutType == 1)
        {
            return crystalNutCount;
        }
        if (nutType == 2)
        {
            return rewindNutCount; 
        }
        if (nutType == 3)
        {
            return slowTimeNutCount;
        }
        else
        {
            return -1;
        }
    }
}
