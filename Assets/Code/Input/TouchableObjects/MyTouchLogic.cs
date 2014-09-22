using UnityEngine;
using System.Collections;

public class MyTouchLogic : MonoBehaviour 
{
	//Swipe variables
	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;
	public int bufferLength;
	public bool fingerMoved;

	public static MyTouchLogic mytouchlogic;
	//public MyTouchLogic mytouch;
	public bool swipeRight, swipeLeft;
	//public static MyTouchLogic thistouch;

	//Gui Variables
	GUIStyle smallFont;
	GUIStyle largeFont;
	void Awake()
	{
		mytouchlogic = GameObject.Find("Gestures").GetComponent<MyTouchLogic>();
		}
	public void Start()
	{
		//mytouch =  GameObject.Find("Gestures").GetComponent<MyTouchLogic>();
	}
	void FixedUpdate()
	{

		//reset variables
		swipeLeft = false;
		swipeRight = false;
		SwipeDetection ();
	}

	//Detection of screen swipe
	public void SwipeDetection()
	{

		bufferLength = Screen.width/15;

	
		//Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			//Handle finger movements based on touch phase.
			switch (touch.phase)
			{
				//Record initial touch position.
			case TouchPhase.Began:
				startPos = touch.position;
				
				directionChosen = false;
				fingerMoved = false;
				direction.x = 0;
				break;
				// Determine direction by comparing the current touch
				// position with the initial one.
			case TouchPhase.Moved:
				direction = touch.position - startPos;
				if (!fingerMoved)
					directionChosen = true;
				break;
				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				//directionChosen = false;
				break;
			}
		}

		if (directionChosen) 
		{
			if (direction.x > bufferLength)
				{
					swipeRight = true;
					fingerMoved = true;
				directionChosen = false;
			}
			if (direction.x <  -bufferLength)
				{ 
					swipeLeft = true;
					fingerMoved = true;
				directionChosen = false;
				}
		}
		
	}

	//For debugging purposes.
	/*void OnGUI() {
		smallFont = new GUIStyle();
		largeFont = new GUIStyle();
		
		smallFont.fontSize = 10;
		largeFont.fontSize = 35;

		//if (directionChosen)
		//{


		if (direction.x > bufferLength)
		{
			GUI.color = Color.red;
			GUI.Box(new Rect(10, 40, 150, 25), "You have swiped towards the Right!", largeFont);
		}
		else if (direction.x <  -bufferLength)
		{ 
			GUI.color = Color.blue;
			GUI.Box(new Rect(10, 40, 150, 25), "You have swiped towards the Left!", largeFont);
		}
		else
		{
			GUI.color = Color.blue;
			GUI.Box(new Rect(10, 40, 150, 25), "No swipe detected!", largeFont);
		}
		//}




		GUI.Box(new Rect(10, 70, 150, 25), -bufferLength + " < " + direction.x + " > " + bufferLength, largeFont);

	}*/
}

