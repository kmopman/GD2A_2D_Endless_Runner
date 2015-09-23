using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //gameobjects
    private GameObject picture;
    private GameObject logo;

    private GameObject baseball;

    [SerializeField]
    private GameObject htPlayer;
    [SerializeField]
    private GameObject howToPlay;
    //gameobjects
   



    void Start()
    {

        //Find all the gameobjects!
        picture = GameObject.Find("Picture");
        logo = GameObject.Find("Logo");

        baseball = GameObject.Find("BaseBall");
        //htPlayer = GameObject.Find("HTPlayer");

    
        //Find all the gameobjects!

    }

	public void Level1 (string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
	
	public void HowToPlay () {
        Debug.Log("lick");
        Destroy(baseball.gameObject);
        Destroy(picture.gameObject);
        Destroy(logo.gameObject);
        htPlayer.SetActive(true);
        howToPlay.SetActive(true);
	}
	
	public void Level3 (string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
