using UnityEngine;
using System.Collections;

public class Soda : Pickup 
{
    //gameobjects
    private GameObject scoreUp;
    //gameobjects

    //floats
    private float scoreTimer = 2f;
    //floats

    //bool
    private bool hasScoreText = false;
    //bools

    void Start ()
    {
        scoreUp = GameObject.Find("1000");
    }

    void Update()
    {
        ShowScore();
    }

    void ShowScore()
{
    if (hasScoreText == true)
    {
        scoreTimer -= Time.deltaTime;

        if (scoreTimer <= 0)
        {
            hasScoreText = false;
        }
    }

}

    public override void PlayerHit(PlayerMovement _SC)
    {
        hasScoreText = true;
        scoreUp.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		GameObject scoreText = GameObject.Find("ScoreText");  
		ScoreManager scoreManager = scoreText.GetComponent<ScoreManager>();
		scoreManager.scoreCounter += 1000;
        base.PlayerHit(_SC);
    }
}
