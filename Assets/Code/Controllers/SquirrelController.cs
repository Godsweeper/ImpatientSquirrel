using UnityEngine;
using System.Collections;

//Controller class for the Squirrels movement functionality
public class SquirrelController : MonoBehaviour
{
	#region Public Variables
	public float Speed;             //Movement speed of the squirrel
	public bool sapped;             //Check for if the squirrel has moved over sap or not
	public TouchTile parentTile;    //Current Parent Tile of the squirrel    
	#endregion
	
	public GameObject rocketPrefab;

	
	void Start()
	{
		FindPath.alive = false;
	}
	
	void Update()
	{
		//Assigning the Parent Tile for the squirrel
		//If the parent of the squirrel is not null
		if (transform.parent != null)
		{        
			//Assign the Parent Tile to the squirrels current parent
			parentTile = transform.parent.GetComponent<TouchTile>();           
		}
		//Else if the parent of the squirrel exists
		else
		{
			//Set Parent Tile to null
			parentTile = null;
		} 
	}
	
	void FixedUpdate()
	{
		//If the current game(Puzzle) has started, hasnt ended and is not paused (Currently in play)
		if (GameManager.Instance.gameStarted == true && GameManager.Instance.gameEnd == false && GameManager.Instance.paused == false)
		{
			//If the squirrels Parent Tile does exist
			if (parentTile != null)
			{
				if(!FindPath.alive)
				{
					Instantiate(rocketPrefab, transform.position, transform.rotation);
					//rocketInstance.layer = 13;
					//Physics2D.IgnoreLayerCollision (rocketInstance.layer, gameObject.layer);
				}
				//if the Sqiurrels parent tile is not moving from Input
				if (parentTile.moving == false)
				{
					//Set suirrel to Non-Kinematic
					rigidbody2D.isKinematic = false;
					//If the squirrel is moving vertically 
					if (GameManager.Instance.movingVertical == true)
					{
						//If moving Up                     
						if (GameManager.Instance.movingUpDown == true)
						{
							//Change velocity to the Upwards direction
							rigidbody2D.velocity = new Vector2(Speed / 2f, Speed);
						}
						//Else if moving down
						else
						{
							//Change velocity to the Downwards direction
							rigidbody2D.velocity = new Vector2(0.0f, -Speed);
						}
					}
					//Else if the squirrel is not moving vertically
					else
					{
						//Change velocity towards the Right
						rigidbody2D.velocity = new Vector2(Speed, rigidbody2D.velocity.y);
					}
				}
				//Else if the squirrels Parent Tile is moving from Input
				else             
				{
					//Set the Squirrel to Kinematic
					rigidbody2D.isKinematic = true;
				}
			}
			//Else if the Squirrels Parent Tile doesn't exist
			else
			{
				//Set the Squirrel to Non-Kinematic
				rigidbody2D.isKinematic = false;
			}
		}
		//Else if the current game(Puzzle) is not in play
		else
		{
			//Set the Squirrel to Kinematic
			rigidbody2D.isKinematic = true;
		}
	}
	
	
}
