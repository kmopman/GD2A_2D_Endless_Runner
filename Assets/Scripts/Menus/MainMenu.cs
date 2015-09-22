using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{	
	public void Level1 (string sceneToChangeTo)
    {
		Application.LoadLevel(sceneToChangeTo);
	}
}
