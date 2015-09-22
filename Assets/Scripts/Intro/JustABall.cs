using UnityEngine;
using System.Collections;

public class JustABall : MonoBehaviour 
{

	//floats
	private float movementSpeed = 15f;
    //floats

	void Start () 
    {
		StartCoroutine ("waitThreeSeconds");  
	}

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(9);
    }


	void Update () 
    {
        MoveObject();
	}

   

    void MoveObject()
    {
            this.transform.position += Vector3.left * Time.deltaTime * movementSpeed;
    }


}
