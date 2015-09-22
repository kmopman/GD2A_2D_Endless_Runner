using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
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


    //bools
    private bool spawnObjects = true;
    //bools
    
	void Start ()
    {
        obstacleTimer = delayTimer;
		lampTimer = delayTimer;
	}
	
	void Update ()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (spawnObjects == true)
        {
            ObstacleSpawner();
            LampSpawner();
        }

        if (playerMovement.deathCounter == 3)
        {
            spawnObjects = false;
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
