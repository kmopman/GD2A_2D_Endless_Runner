using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Splashscreen : MonoBehaviour 
{
	public float timer = 2.5f;
	private float waitTimer = 1f;
	public string levelToLoad = "Menu";
	public Image splash;
	Color colorToFadeTo;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("DisplayScene");
	}

	void Update()
	{
		if (Input.anyKeyDown)
			Application.LoadLevel (levelToLoad);
	}

	IEnumerator DisplayScene () 
	{
		yield return new WaitForSeconds (waitTimer);
		colorToFadeTo = new Color (1f, 1f, 1f, 0f);
		splash.CrossFadeColor (colorToFadeTo, timer, true, true);
		yield return new WaitForSeconds (timer);
		Application.LoadLevel (levelToLoad);
	}
}
