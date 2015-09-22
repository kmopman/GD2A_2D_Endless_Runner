using UnityEngine;
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

    //audio
    private GameObject clockSFX;
    //audio



    void Awake()
    {
        GameObject clockSFX = GameObject.FindGameObjectWithTag("ClockSFX");
    }

    void Update()
    {
        Debug.Log(letItGo);
        Debug.Log(slowTimer);

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
        GetComponent<AudioSource>();
        letItGo = true;
        base.PlayerHit(_SC);
        Debug.Log("Slow...");
    }
}
