using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Pickup
{
    private GameObject shield;

    private float shieldTimer = 5f;
    private bool shieldBool = false;


    void Start()
    {
        shield = GameObject.Find("PlayerShield");
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
        shieldBool = true;
        shield.SetActive(true);
        base.PlayerHit(_SC);
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