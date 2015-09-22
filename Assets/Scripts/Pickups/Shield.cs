using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Pickup 
{
	private GameObject shield;

    [SerializeField]
    private AudioSource shieldSFX;

    Transform parentObject;

	void Awake() {
		shield = GameObject.Find ("PlayerShield");
	}

    public override void PlayerHit(PlayerMovement _SC)
    {
        shieldSFX.Play();
		shield.SetActive(true);
        base.PlayerHit(_SC);
        Debug.Log("SHIELD!");
    }
}
