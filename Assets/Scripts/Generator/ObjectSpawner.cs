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
	private float obstacleTimer;
	[SerializeField]
	private float lampTimer;
	//floats



	// Use this for initialization
	void Start () {
        obstacleTimer = delayTimer;
		lampTimer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {

		ObstacleSpawner ();
		LampSpawner ();

        if (Time.timeScale <= 0.9)
        {
            DeleteObjects();
        }
	}

	void ObstacleSpawner() 
	{
        obstacleTimer -= Time.deltaTime;

        if (obstacleTimer <= 0) 
		{	
			Instantiate (pickups[Random.Range(0, pickups.Length)]);
            obstacleTimer = Random.Range(minTimer, maxTimer);

		}
	}

	void LampSpawner()
	{
        int i = lamps.Length;
		lampTimer -= Time.deltaTime;

        if (lampTimer <= 0)
        {
            for (var l = 0; l < i; l++)
            {
                Instantiate(lamps[i]);
                lampTimer = maxTimer;
            }
        }
        
			
		}

    void DeleteObjects()
    {
       //
    }
}
