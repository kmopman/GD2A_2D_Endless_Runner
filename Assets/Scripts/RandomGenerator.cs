using UnityEngine;
using System.Collections;

public class RandomGenerator : MonoBehaviour {
	
	public enum Elements
	{
		Fire,
		Water,
		Earth,
		Wind
	}

	public Elements elements;
	private MeshRenderer renderer;

	void Start () {
		
		renderer = GetComponent<MeshRenderer> ();
		//elementsTest = Elements.Air;
		//elements = elements.GetValues(typeof(Elements));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			ChangeColor();
		}
	}
	
	void ChangeColor()
	{
		
		elements = (Elements)Random.Range (0,4);
		Color newColor = new Color ();
		Debug.Log (elements);
		
		switch (elements) 
		{
		case Elements.Earth:
			newColor = Color.black;
			break;
		case Elements.Water:
			newColor = Color.blue;
			break;

		case Elements.Fire:
			newColor = Color.red;
			break;

		case Elements.Wind:
			newColor = Color.grey;
			break;

		default:
			newColor = Color.red;
			break;
		}

		renderer.material.color = newColor;
		
	}
}
