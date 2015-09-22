using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
   
    //floats
	private float seconds = 3f;
	public float scoreCounter;
    //floats


    //bools
    private bool runScore = false;
    //bools

    //text
    [SerializeField]
    private Text scoreText;
    //text


	void Start () 
	{
		StartCoroutine ("waitSeconds");
	}

	IEnumerator waitSeconds() 
	{
		yield return new WaitForSeconds (seconds);
        runScore = true;
	}
	
	void Update () 
	{
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();


        if (playerMovement.deathCounter <= 2)
        {
            CountScore();
        }
        
    }


    void CountScore()
    {
        if (runScore == true)
        {
            SetScoreText();
            scoreCounter++;
        }
    }

	void SetScoreText()
	{
		scoreText.text = "Score: " + scoreCounter.ToString ();
	}
}
