using UnityEngine;
using System.Collections;

public class ReturnToMain : MonoBehaviour {
	
	public void MainMenu (string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
