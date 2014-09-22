using UnityEngine;
using System.Collections;

//Base class for a touchable game object
public class TouchableObject : MonoBehaviour, ITouchable2D
{
    //Virtual function for swipe functionality
    public virtual void SwipeEffect(FingerGestures.SwipeDirection direction, SwipeGesture gesture)
    {
        //Log debug message
        Debug.Log("Swiped: " + this.transform);
    }

    //Overriden Interface OnSwipeGameObject function
    public void OnSwipeGameObject(SwipeGesture gesture)
    {
        //If the game has started
        if (GameManager.Instance.gameStarted == true)
        {
            //Call Swipe functionality for this object
            SwipeEffect(gesture.Direction, gesture);
        }
    }

    //Overriden Interface OnSwipeAnywhere function
    public void OnSwipeAnywhere(SwipeGesture gesture)
    {
        //Log debug message
        Debug.Log("Swipe should not happen");
    } 
}
