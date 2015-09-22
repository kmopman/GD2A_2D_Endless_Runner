using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Pickup 
{
    //gameobjects
	private GameObject shield;
    //gameobjects

    //floats
    private float shieldTimer = 5f;
    //floats

    //bools
    private bool shieldBool = false;
    //bools

    void Awake()
    {
		shield = GameObject.Find ("PlayerShield");
	}

    void Update()
    {
        if (shieldBool == true)
        {
            ShieldTimer();
        }
    }

    public override void PlayerHit(PlayerMovement _SC)
    {
        base.PlayerHit(_SC);
        Debug.Log("SHIELD!");
    }

    void ShieldTimer()
    {
        shieldTimer -= Time.deltaTime;

        shield.SetActive(true);

        if (shieldTimer <= 0)
        {
            shield.SetActive(false);
            shieldBool = false;
        }
    }
}
