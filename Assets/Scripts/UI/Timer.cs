using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
    [SerializeField]
    private Text timerText;

    private float timerCounter;

	void Update () 
    {
        timerCounter += Time.deltaTime;

        var minutes = timerCounter / 60;
        var seconds = timerCounter % 60;
        var fraction = (timerCounter * 100) % 100;

        timerText.text = string.Format(" Time: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
