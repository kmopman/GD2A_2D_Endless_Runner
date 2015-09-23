using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowDownClock : Pickup
{
    //floats
    private float slowTimer = 2.5f;
    //floats

    //bools
    private bool letItGo = false;
    //bools

    void FixedUpdate()
    {
        if (letItGo == true)
        {
            SlowDown();
        }

    }
    void SlowDown()
    {

       

        letItGo = true;

        if (letItGo == true)
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
    }

    public override void PlayerHit(PlayerMovement _SC)
    {
        letItGo = true;
        //SlowDown();
        base.PlayerHit(_SC);
    }
}