using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	//public GameManager gameManager;

	//floats
	public float speed;
	public float jumpHeight;
	//floats

	//strings
	public string pickUps;
	//strings

	//int
	public int jumps = 0;
	//int

	//bool
	public bool spacePressed;
	public bool grounded;
	public bool goSign = false;
	//bool

	//audio
	public AudioSource jumpSFX;
	public AudioSource itemSFX;
	//audio

	//animator
	Animator anim;
	//animator


	void Awake ()
	{
		StartCoroutine ("waitThreeSeconds"); //wacht drie seconden
		anim = GetComponent<Animator> ();
		grounded = false;
	}
	

	IEnumerator waitThreeSeconds()
	{
		yield return new WaitForSeconds (3);
		//Debug.Log ("Works!");
		goSign = true;
	}

	void FixedUpdate () 
	{
		if (goSign == true) //als de drie secondes afgelopen zijn, voer dit dan uit.
		{
			Animation();
			Jump ();
		}

	}

	void Animation()
	{
		anim.SetBool ("Skating", true);
	}

	void Move ()
	{


		//CROUCHING
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			Debug.Log ("Test");
		}
		//CROUCHING
	}
	
	void Jump () 
	{
		if (!spacePressed && Input.GetKey (KeyCode.Space) && jumps < 2) {
			spacePressed = true;
			//jumpSFX.Play ();
			anim.SetBool ("Jump", true);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, jumpHeight);
			grounded = false;
			jumps++;

		} else if (!Input.GetKey(KeyCode.Space))
		{
			spacePressed = false;
		}
		
	}

	void OnCollisionEnter2D (Collision2D hit)
	{
		grounded = true;
		anim.SetBool ("Jump", false);
		//anim.SetInteger ("AnimationState", 0);
		jumps = 0;
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == pickUps) 
		{
			//itemSFX.Play ();
			//gameManager.AddCollectable();
			Destroy(other.gameObject);
		}
	}
}
