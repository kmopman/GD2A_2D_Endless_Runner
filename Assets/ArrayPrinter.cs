using UnityEngine;
using System.Collections;

public class ArrayPrinter : MonoBehaviour {

	public GameObject[] myArrayObject;

	void Start() {
		PrintArray ();
	}

	void PrintArray()
	{
		int l = myArrayObject.Length;
		for (int i = 0; i < l; i++)
		{
			Debug.Log (myArrayObject [i].name);
			Debug.Log (l);
		}
	}
}
