using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public bool isGrounded;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Jump Function
		if(Input.GetKeyDown("space") && isGrounded)
			{	
				isGrounded = false;
				transform.GetComponent<Rigidbody> ().velocity += 7 * Vector3.up;
			}
		//Movement functions
		if (Input.GetKey ("a")) {
			float movementSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
			transform.Translate (movementSpeed, 0, 0);
		}
		else if( Input.GetKey("d"))
		{			
			float movementSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
			transform.Translate (movementSpeed, 0, 0);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		// calls enemy to kill enemy
		if ((other.gameObject.tag == "Enemy") && !isGrounded) {
			other.gameObject.GetComponent<EnemyScript> ().TouchedByPlayer ();
			GameObject.Find ("UI").GetComponent<PointsCounter> ().enemyCounter += 1;
			GameObject.Find ("UI").GetComponent<PointsCounter> ().MakeNewEnemies ();
		} else if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyScript> ().TouchedPlayer ();
			GameObject.Find ("UI").GetComponent<PointsCounter> ().health -= 5;
		}
	}

	void OnCollisionStay(Collision other)
	{
		// check to see if the player is grounded
		if (other.gameObject.name == "Floor") {
			isGrounded = true;
		} else
			isGrounded = false;
	}

	void OnCollisionExit(Collision other)
	{
		// check to see if the player has jump
		if (other.gameObject.name == "Floor") {
			isGrounded = false;
		}
	}
}
