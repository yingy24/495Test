using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour {

	public GameObject enemyGameObj;
	public float points, health;
	public int enemyCounter;
	public Text pointsUI, healthUI;

	// Use this for initialization
	void Start () {
		points = 0;
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		pointsUI.text = points.ToString();
		healthUI.text = health.ToString ();
	}

	// makes new enemies when old one is killed
	public void MakeNewEnemies()
	{
		int randomLocation = Random.Range (-12, 12);
		if (enemyCounter < 2)
			Instantiate (enemyGameObj, new Vector3 (randomLocation, 0, 0), Quaternion.identity);
		else {
			Instantiate (enemyGameObj, new Vector3 (randomLocation, 0, 0), Quaternion.identity);
			Instantiate (enemyGameObj, new Vector3 (randomLocation, 0, 0), Quaternion.identity);
		}

		}
	}

