using UnityEngine;
using System.Collections;

public class FindPath : MonoBehaviour {
	
	public static bool alive;
	public static bool reset, resetCheck;
	public int x,y;
	public GameObject mySquirrel;
	public SquirrelController myControl;
	public bool activate;
	public float myTimer;

	//ground variables
	bool grounded = false;//Default the player is not on the ground
	bool aHit = false;
	public Transform branchCheck, frontColliderCheck;
	float colliderRadius = 0.5f;
	public LayerMask theGroundLayer, theAcornLayer;

	void Awake()
	{
		mySquirrel = GameObject.FindWithTag ("Player");//Locate Player GameObject
		myControl = mySquirrel.GetComponent<SquirrelController>();//Locate SquirrelController Script
		gameObject.layer = 14;//Set layer
		Physics2D.IgnoreLayerCollision (mySquirrel.layer, gameObject.layer);//Ignore collision
		gameObject.transform.position = mySquirrel.transform.position;//Reset Position
		alive = true;
		reset = false;
		activate = true;
		myTimer = GameManager.Instance.tileSwipeTime;
	}
	
	
	void Update()
	{
		rigidbody2D.velocity = new Vector2 (x, y);//Set velocity in the inspector
		print (GameManager.Instance.tileSwipeTime);
		if (reset)
		{
			myTimer -= Time.deltaTime;
		if (myTimer <= 0.0f)
		{
				print ("Resetting findpath position.");
				gameObject.transform.position = mySquirrel.transform.position;//Reset Position
				reset = false;//reset condition
				resetCheck = false;
				activate = true;
				myTimer = GameManager.Instance.tileSwipeTime;

		}
		}
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (branchCheck.position, colliderRadius, theGroundLayer);
		if (!grounded && activate)
		{
			Debug.Log ("You fell off!");

				activate = false;
			myControl.Speed = 2;
		}
		aHit = Physics2D.OverlapCircle (frontColliderCheck.position, colliderRadius, theAcornLayer);
		if(aHit)
		{
			Debug.Log ("We have a hit!");

		}
	}
	
	
	void  OnTriggerStay2D(Collider2D coll)
	{
		//Check collision with finish
		if (activate)
		{
			if (coll.tag == "Finish" )
			{
				myControl.Speed = 4;//Increas squirrels speed
				activate = false;
				//Destroy (gameObject);
				//Make variable to stop player input for moving tiles!!!!!!!
			}
		}
		
	}
	

	
	
	
	
	
	

}
