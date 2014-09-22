using UnityEngine;
using System.Collections;

public class TouchLogic2D : MonoSingleton<TouchLogic2D>
{    
    #region Private variables
    private ITouchable2D touchedObject = null;  //temp instance of a 2D touchable gameobject Interface
    #endregion

    void OnSwipe(SwipeGesture gesture)
    {
        //If a game object has been selected at the start of the swipe
        if (gesture.StartSelection != null)
        {
            //if the selected gameobject has a ITouchable2D instance then assign it to touchedObject
            touchedObject = gesture.StartSelection.gameObject.GetComponent(typeof(ITouchable2D)) as ITouchable2D;
            //if there isnt an ITouchable2D instance on the gameobject then it will stay Null
            //if the touchedObject is not null
            if (touchedObject != null)
            {
                #region Commented
                //swipeStartPos = Utility.Instance.GetWorldPos(gesture.Position);
                /*if (gesture.Direction == FingerGestures.SwipeDirection.Up)
                {
                    touchedObject.OnSwipeUp(gesture);
                }
                if (gesture.Direction == FingerGestures.SwipeDirection.Down)
                {
                    touchedObject.OnSwipeDown(gesture);
                }
                if (gesture.Direction == FingerGestures.SwipeDirection.Left)
                {
                    touchedObject.OnSwipeLeft(gesture);
                }
                if (gesture.Direction == FingerGestures.SwipeDirection.Right)
                {
                    touchedObject.OnSwipeRight(gesture);
                }*/
                #endregion
                //Call swipe function for the gameobject that has been swiped on
                touchedObject.OnSwipeGameObject(gesture);
            } 
        }
        
    }

    /*void OnTap(TapGesture gesture)
   {
       if (gesture.Selection != null)
       {
           touchedObject = gesture.Selection.transform.GetComponent(typeof(ITouchable2D)) as ITouchable2D;
       }
       Debug.Log("Tapped: " + touchedObject);
       if (touchedObject != null)
       {
           touchedObject.OnTap(gesture);
       }
   }*/

   
}
