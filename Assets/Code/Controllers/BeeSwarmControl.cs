using UnityEngine;
using System.Collections;

public class BeeSwarmControl : MonoBehaviour {

	public float moveSpeed;
	public GameObject playerPosition;

	void Start()
	{
		playerPosition = GameObject.FindWithTag ("Player");//Locate Player GameObject
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerPosition.transform.position, (moveSpeed * Time.deltaTime));
		transform.LookAt(playerPosition.transform.position);
	}
}
