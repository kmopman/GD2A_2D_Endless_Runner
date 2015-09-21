using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision2d)
	
	{
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		Destroy (gameObject);
	}
}
