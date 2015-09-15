using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	// Update is called once per frame

	private float seconds;
	private GameObject waitingObject;

	void Awake()
	{
		Appear ();
	}
	
	void Appear ()
	{
		StartCoroutine ("waitSeconds");
	}

	IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds (seconds);
		Debug.Log ("Test?");
		waitingObject.SetActive (true);
	}


}
