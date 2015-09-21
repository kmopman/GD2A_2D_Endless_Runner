using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	//public GameManager gameManager;

	//player
	[SerializeField]
	private GameObject player;
	//player

	//floats
	private float jumpHeight = 8.0f;
	private float deathBraking = -5.0f;
	//floats

	//strings
	[SerializeField]
	private string pickUps;
	//strings

	//int
	private int jumps = 0;
	private int seconds = 3;
	private int deathCounter = 0;
	private int deathDelay = 3;
	//int

	//bool
	[SerializeField]
	private bool spacePressed;
	[SerializeField]
	private bool grounded;
	[SerializeField]
	private bool goSign = false;
	private bool brakingDeath = false;
	//bool

	//audio
	[SerializeField]
	private AudioSource jumpSFX;
	//public AudioSource itemSFX;
	//audio

	//animator
	Animator anim;
	//animator


	void Awake ()
	{
		StartCoroutine ("waitThreeSeconds"); //wacht drie seconden
		anim = GetComponent<Animator> (); //grijpt de animator zodat ie daar wijzigingen in kan maken
		grounded = false; // je begint niet op de grond
	}

	void Start ()
	{
		anim.SetBool ("Jump", true); //je start de game op in je jump animatie
	}
	

	IEnumerator waitThreeSeconds()
	{
		yield return new WaitForSeconds (seconds);
		anim.SetBool("Skating", true);
		goSign = true;
	}

	void FixedUpdate () 
	{
		if (goSign == true) 
		{
			Movement ();
		}

		if (jumps == 1) 
		{
			anim.SetBool("Jump", true);
			anim.SetBool ("Crouch", false);
		}

		anim.speed += 0.0003f;

		//Pause ();
			
	}
	
	void Movement () 
	{
		//JUMP
		if (!spacePressed && Input.GetKey (KeyCode.Space) && jumps < 2) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, jumpHeight);
			anim.SetBool ("Crouch", false);
			anim.SetBool ("Skating", false);
			spacePressed = true;
			grounded = false;
			jumpSFX.Play ();
			jumps++;
	
		}
		//JUMP


		//CROUCHING
		if (Input.GetKeyDown (KeyCode.Z) && grounded == true) {
			anim.SetBool ("Skating", false);
			anim.SetBool ("Crouch", true);
			//this.transform.localScale = new Vector2 (1.6f,1f);
		} else if (Input.GetKeyUp (KeyCode.Z) && grounded == true) 
		{
			anim.SetBool ("Crouch", false);
			anim.SetBool ("Skating", true);
			//this.transform.localScale = new Vector2 (1.5f,1.5f);
		}
		//CROUCHING

		else if (!Input.GetKey(KeyCode.Space))
		{
			spacePressed = false;
		}


		
	}

	void Pause(){

		if (deathCounter >= 3)
		{
			deathBraking -= 0.001f;
			this.transform.Translate (transform.position.x, transform.position.y,transform.position.z);
		}
		

	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (goSign == true) 
		{
			anim.SetBool ("Skating", true);
		}


		grounded = true;
		anim.SetBool ("Jump", false);

		jumps = 0;

		if (coll.gameObject.tag == "Obstacle") 
		{
			deathCounter++;

			if (deathCounter >= 3)
			{
				anim.SetBool("Skating", false);
				anim.SetBool("Death", true);

			}


			Debug.Log (deathCounter);
		}

		if (coll.gameObject.tag == "PickUp") 
		{
			Time.timeScale =  0.5f;
			Destroy(coll.gameObject);
		}
	}
}
