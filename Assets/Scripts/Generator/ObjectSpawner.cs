using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {
	



	//gameobjects
	[SerializeField]
	private GameObject[] pickups;

	[SerializeField]
	private GameObject[] lamps;
	//gameobjects

	//floats
	private float minTimer = 1f;
	private float maxTimer = 3f;
	[SerializeField]
	private float delayTimer = 3f;
	private float timer;
	[SerializeField]
	private float lampTimer;
	//floats



	// Use this for initialization
	void Start () {
		timer = delayTimer;
		lampTimer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {

		ObstacleSpawner ();
		LampSpawner ();
	}

	void ObstacleSpawner() 
	{


		timer -= Time.deltaTime;

		if (timer <= 0) 
		{	
			Instantiate (pickups[Random.Range(0, pickups.Length)]);
			timer = Random.Range(minTimer, maxTimer);

		}
	}

	void LampSpawner()
	{
		int i = lamps.Length - 1;
		lampTimer -= Time.deltaTime;

		if (lampTimer <= 0) 
		{	
			Instantiate (lamps[i]);
			lampTimer = maxTimer;
			
		}
	}
}
