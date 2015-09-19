using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	[SerializeField]
	//floats
	private float speed = 0.0f;
	private float limitspeed;
	//floats

	//bools
	private bool goSign = false;
	//bools

	//int
	[SerializeField]
	private int seconds = 3;
	//int

	// Use this for initialization
	void Start () {
		StartCoroutine ("waitThreeSeconds");
	}

	IEnumerator waitThreeSeconds()
	{
		yield return new WaitForSeconds (seconds);
		goSign = true;
	}

	// Update is called once per frame
	void Update () {

		if (goSign == true) {
			Vector2 offset = new Vector2 (Time.time * speed, 0);

			if (speed <= 0.001) {
				speed += 0.0001f;
			} else if (speed >= 0.1) {
				speed += 0.00005f;
			} else {
				speed += 0.00001f;
			}

			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		}
	}
}
