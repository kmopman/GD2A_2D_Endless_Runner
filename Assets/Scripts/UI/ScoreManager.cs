using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	[SerializeField]
	private Text scoreText;

	private float seconds = 3f;
	private float scoreCounter;

	private bool runText = false;

	void Start () 
	{
		StartCoroutine ("waitThreeSeconds");
		//SetScoreText ();
	}

	IEnumerator waitThreeSeconds() 
	{
		yield return new WaitForSeconds (seconds);
		runText = true;
	}
	
	void Update () 
	{
		if (runText == true) 
		{
			SetScoreText ();
			scoreCounter++;
		}

	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + scoreCounter.ToString ();
	}
}
