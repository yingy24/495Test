using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript: MonoBehaviour {

	public Transform player;
	public float speed;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (this.transform.position, player.position,  step);

	}

	// this function is called when a player jumps on it
	public void TouchedByPlayer()
	{
		GameObject.Find("UI").GetComponent<PointsCounter>().points += 1;
		Destroy(this.gameObject);
	}

	// this function is called when a player runs into it
	// or the enemy runs into the player
	public void TouchedPlayer()
	{
		Destroy(this.gameObject);
	}

	// Spawns in new enemies when an enemy die


}
