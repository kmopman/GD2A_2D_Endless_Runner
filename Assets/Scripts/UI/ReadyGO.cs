using UnityEngine;
using System.Collections;

public class ReadyGO : MonoBehaviour
{
    //gameobjects
    private GameObject readyText;
    private GameObject goText;
    //gameobjects

    //int
    private int readySeconds = 3;
    private int goSeconds = 1;
    //int

    void Awake()
    {
        StartCoroutine("WaitForReady");
    }
    void Start()
    {
        goText = GameObject.Find("GO");
        readyText = GameObject.Find("Ready");
    }

    IEnumerator WaitForReady()
    {
        yield return new WaitForSeconds(readySeconds);
        Destroy(readyText.gameObject);
        goText.SetActive(true);
    }
}
