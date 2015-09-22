using UnityEngine;
using System.Collections;

public class DeactiveOnStart : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
