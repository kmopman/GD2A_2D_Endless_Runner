using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	// Update is called once per frame

	public float seconds;
	public GameObject waitingObject;

	void Start() 
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
