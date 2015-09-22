using UnityEngine;
using System.Collections;

public class Soda : Pickup 
{
    public override void PlayerHit(PlayerMovement _SC)
    {
		GameObject scoreText = GameObject.Find("ScoreText");  
		ScoreManager scoreManager = scoreText.GetComponent<ScoreManager>();
		scoreManager.scoreCounter += 1000;
        base.PlayerHit(_SC);
        Debug.Log("1000 points!");
    }
}
