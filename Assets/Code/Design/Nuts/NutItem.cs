using UnityEngine;
using System.Collections;

//Base class for Nut items to be used in gameplay
public class NutItem : MonoBehaviour
{
    #region Public Variables
    public string nutName;      //Name of the Nut
    public Texture itemButton;  //Texture of the Nut's button
    #endregion

    //Virtual function the be overriden by extended nut classes
    //Control's what effect the nut has on gameplay when used
    public virtual void NutEffect()
    {

    }
}
