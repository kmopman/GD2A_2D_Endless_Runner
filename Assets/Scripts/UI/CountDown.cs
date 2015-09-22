using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

	// Update is called once per frame

	[SerializeField]
	private float seconds;
	[SerializeField]
	private GameObject waitingObject;

    [SerializeField]
    private bool findObject = false;


    //GameObjects
    private GameObject intro1;
    private GameObject intro2;
    private GameObject intro3;

    private GameObject logo;
    //GameObjects


	void Awake()
	{
		Appear ();
	}
	
	void Appear ()
	{
		StartCoroutine ("waitSeconds");
	}

    void Update ()
    {

        removeObjects();
    }

    void removeObjects()
    {

        if (findObject == true)
        {
            logo = GameObject.Find("Logo");
            intro1 = GameObject.Find("Intro1");
            intro2 = GameObject.Find("Intro2");
            intro3 = GameObject.Find("Intro3");
            

            if (logo.activeSelf == true)
            {
                Destroy(intro1.gameObject);
                Destroy(intro2.gameObject);
                Destroy(intro3.gameObject);
            }
        }
    }

	IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds (seconds);
		waitingObject.SetActive (true);
	}


}
