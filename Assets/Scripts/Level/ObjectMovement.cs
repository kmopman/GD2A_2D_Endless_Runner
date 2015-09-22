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
    private bool runSpeed = true;
	//bools


	void Start () 
    {
		StartCoroutine ("waitSeconds");  
	}
	
	IEnumerator waitSeconds()
	{
		yield return new WaitForSeconds (seconds);
		goSign = true;
	}
	
	void Update () 
    {
        CheckStatus();
	}

    void CheckStatus()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement.deathCounter >= 3)
        {
            runSpeed = false;
        }

        if (runSpeed == true)
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
