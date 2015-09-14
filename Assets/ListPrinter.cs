using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	public class ListPrinter : MonoBehaviour {

	public List<GameObject> myList = new List<GameObject>();

	void Start()
	{
		PrintList ();
	}

	void PrintList()
	{
		GameObject myGameObject = new GameObject ("Obj1");
		GameObject myGameObject1 = new GameObject ("Obj2");
		GameObject myGameObject2 = new GameObject ("Obj3");
		GameObject myGameObject3 = new GameObject ("Obj4");
		
		myList.Add (myGameObject);
		myList.Add (myGameObject1);
		myList.Add (myGameObject2);
		myList.Add (myGameObject3);


		int c = myList.Count;
		for (int i = 0; i < c; i++)
		{
			Debug.Log (myList[i]);
			Debug.Log (myList.Count);
		}

	}

}
