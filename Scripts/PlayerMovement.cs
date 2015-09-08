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
	//bool

	public AudioSource jumpSFX;
	public AudioSource itemSFX;
	
	Animator anim;
	
	void Awake ()
	{
		anim = GetComponent<Animator> ();
		grounded = false;
	}
	
	
	void FixedUpdate () 
	{
		Move ();
		Jump ();
	}
	
	void Move ()
	{
		float x = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (x, 0f);
		transform.Translate (movement * speed * Time.deltaTime);
		
		anim.SetFloat ("Speed", Mathf.Abs (x));


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
			anim.SetInteger ("AnimationState", 2);
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
		anim.SetInteger ("AnimationState", 0);
		jumps = 0;
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == pickUps) 
		{
			itemSFX.Play ();
			//gameManager.AddCollectable();
			Destroy(other.gameObject);
		}
	}
}
