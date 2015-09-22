using UnityEngine;
using System.Collections;

public class Soda : Pickup 
{

    private GameObject sodaSFX;


    public override void PlayerHit(PlayerMovement _SC)
    {
		GameObject scoreText = GameObject.Find("ScoreText");  
		ScoreManager scoreManager = scoreText.GetComponent<ScoreManager>();
		scoreManager.scoreCounter += 1000;
		//Time.timeScale = 0.5f;
        base.PlayerHit(_SC);
        sodaSFX.gameObject.GetComponent<AudioSource>().Play();
        Debug.Log("1000 points!");
    }
}
