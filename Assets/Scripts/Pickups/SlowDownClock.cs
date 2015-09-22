﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowDownClock : Pickup
{
    //floats
    private float slowTimer = 5.0f;
    //floats

    //bools
    private bool letItGo = false;
    //bools

    void Update()
    {
        if (letItGo == true)
        {
             SlowDown();
        }
    }

    void SlowDown()
    {
        slowTimer -= Time.deltaTime;
        Time.timeScale = 0.5f;

        if (slowTimer <= 0)
        {
            letItGo = false;

            if (letItGo == false)
            {
                Time.timeScale = 1.0f;
            }

        }

    }

    public override void PlayerHit(PlayerMovement _SC)
    {
        letItGo = true;
        base.PlayerHit(_SC);
        Debug.Log("Slow...");
    }
}
