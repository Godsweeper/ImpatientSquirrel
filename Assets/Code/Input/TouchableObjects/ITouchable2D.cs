
//Interface class for 2D GameObject Input

public interface ITouchable2D 
{
    //void OnTap(TapGesture gesture);
    //void OnDragStart(DragGesture gesture);
    //void OnDragUpdate(DragGesture gesture);
    //void OnDragEnd(DragGesture gesture);
    //void OnDragEndAnywhere(DragGesture gesture);
    void OnSwipeGameObject(SwipeGesture gesture);       //Base function for Swiping (origin of swipe collideds with a game object)
    void OnSwipeAnywhere(SwipeGesture gesture);         //Base function for Swiping 
}
