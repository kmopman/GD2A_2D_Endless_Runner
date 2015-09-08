using UnityEngine;
using System.Collections;

public class PostURL : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		string url = "http://localhost/bap/pro/action_page.php";

		WWWForm form = new WWWForm ();
	

		form.AddField("var1", "value1");
		form.AddField("var2", "value2");


		WWW www = new WWW(url, form);

		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest (WWW www)

	{
		yield return www;

		if(www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
	

}
