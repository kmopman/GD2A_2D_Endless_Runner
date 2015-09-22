using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour 
{

	//floats
	[SerializeField]
	private float movementSpeed;
    [SerializeField]
    private float seconds = 3;
    //floats
    
	//bools
	private bool goSign = false;
	//bools


	void Start () 
    {
		StartCoroutine ("waitThreeSeconds");
	}
	
	IEnumerator waitThreeSeconds()
	{
		yield return new WaitForSeconds (seconds);
		goSign = true;
	}
	
	void Update () 
    {
        if (Time.timeScale == 1)
        {
            MoveObject();
            IncreaseSpeed();
        }
        
	}


    void MoveObject()
    {
        if (goSign == true)
        {
            this.transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
    }

    void IncreaseSpeed()
    {
        GameObject timerText = GameObject.Find("TimerText");
        Timer timer = timerText.GetComponent<Timer>();

        //Stel hier in na hoeveel SECONDEN je de movementSpeed wilt verhogen.
        if (timer.timerCounter >= 0)
        {
            //Hier kan je de movementSpeed verhogen
				movementSpeed += 0.01f;

        }
    }

}
