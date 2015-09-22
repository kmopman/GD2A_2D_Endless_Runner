using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Splashscreen : MonoBehaviour 
{
    //floats
    public float timer = 2.5f;
	private float waitTimer = 1f;
    //floats

    //strings
	public string levelToLoad = "Menu";
    //strings

    //images
	public Image splash;
    //images

	Color colorToFadeTo;

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
        //Wacht een aantal seconden, laat logo vervagen en nieuw level laden
		yield return new WaitForSeconds (waitTimer);
		colorToFadeTo = new Color (1f, 1f, 1f, 0f);
		splash.CrossFadeColor (colorToFadeTo, timer, true, true);
		yield return new WaitForSeconds (timer);
		Application.LoadLevel (levelToLoad);
	}
}
