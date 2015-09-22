using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    [SerializeField]
    private AudioSource ost;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale <= 0.9)
        {
            StopMusic();
        }
	}

    void StopMusic()
    {
        ost.Stop();
    }
}
