using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	// Update is called once per frame

	[SerializeField]
	private float seconds;
	[SerializeField]
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
