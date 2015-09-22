using UnityEngine;
using System.Collections;

public class JustABall : MonoBehaviour 
{

	//floats
	private float movementSpeed = 5f;
    //floats

	void Start () 
    {
		StartCoroutine ("waitSeconds");  //Begin hier met het aftellen
	}

    IEnumerator waitSeconds()
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
