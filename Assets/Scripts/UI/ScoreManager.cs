using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	[SerializeField]
	private Text scoreText;

	public float scoreCounter;

	void Start () 
	{
		SetScoreText ();
	}
	
	void Update () 
	{
		SetScoreText ();
		scoreCounter++;
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + scoreCounter.ToString ();
	}
}
