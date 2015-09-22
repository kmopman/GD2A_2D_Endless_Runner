using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//player
	[SerializeField]
	private GameObject player;
	//player

	//floats
	private float jumpHeight = 8.0f;
	private float deathBraking = -5.0f;
    private float hitDelay = 1f;
	//floats

	//strings
	[SerializeField]
	private string pickUps;
	//strings

	//int
	private int jumps = 0;
	private int seconds = 3;
    private int hitCounter = 0;
	private int deathCounter = 0;
	private int deathDelay = 3;
	//int

	//bools
	private bool spacePressed;
	private bool grounded;
	private bool goSign = false;
	private bool brakingDeath = false;
    private bool isHit = false;
    private bool hasPlayedSFX = false;
	//bools

	//audio
    [SerializeField]
    private AudioSource jumpSFX;
    [SerializeField]
	private AudioSource hitSFX;
    [SerializeField]
    private AudioSource deathSFX;
    
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

        Debug.Log(hitDelay);

		if (goSign == true) 
		{
			Movement ();
		}

        /* 
         *  De speler begint pas met bewegen na drie seconden.
         */


       

        //functies die per frame geupdate moeten worden
        Death();
        OneSecHit();
        //functies die per frame geupdate moeten worden
			

        for (hitCounter = 0; hitCounter < 3; hitCounter++)
        {
            //
        }
	}
	
	void Movement () 
	{

        anim.speed += 0.0003f; //Naarmate het spel zich vordert, gaat de animatie snelheid sneller.

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

        if (jumps == 1)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Crouch", false);
        }
		//JUMP


		//CROUCHING
		if (Input.GetKeyDown (KeyCode.Z) && grounded == true) {
			anim.SetBool ("Skating", false);
			anim.SetBool ("Crouch", true);
		} 
        
        else if (Input.GetKeyUp (KeyCode.Z) && grounded == true) 
		{
			anim.SetBool ("Crouch", false);
			anim.SetBool ("Skating", true);
		}
		//CROUCHING


		else if (!Input.GetKey(KeyCode.Space))
		{
			spacePressed = false;
		}
        //Laten weten dat de space button NIET ingedrukt is. Dit is noodzakelijk voor de double jump!

		
	}

	void Death(){

		if (deathCounter >= 3 && grounded)
		{
            anim.SetBool("Hit", false);
            anim.SetBool("Skating", false);
            anim.SetBool("Death", true);

            if (!hasPlayedSFX)
            {
                deathSFX.Play();
                hasPlayedSFX = true;
            }
            

            Time.timeScale -= Time.deltaTime;
            //this.GetComponent<Rigidbody2D>().isKinematic = true;

		}
		

	}

	void OnCollisionEnter2D (Collision2D coll)
	{

        grounded = true;
        anim.SetBool("Jump", false);
        jumps = 0;

        /*
         * Wanneer de player de grond aanraakt, laat het spel je dat weten met 'grounded'.
         * Ook wordt de jump animatie hier uitgeschakelt.
         * Aan het begint van het spel, heb je nog nul keer gesprongen.
         */

		if (goSign == true) 
		{
			anim.SetBool ("Skating", true);
		}

        /*
        * Het spel begint met een timer. Met de GoSign boolean, laat het jouw weten dat het spel gestart is.
        * Doordat het spel start, begint de speler ook met skaten.
        */

		

		
	}

    void OneSecHit()
    {
        if (isHit == true && deathCounter <= 2)
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            
            hitDelay -= Time.deltaTime;

            if (hitDelay <= 0.9)
            {
                if(!hasPlayedSFX)
                {
                    hitSFX.Play();
                    hasPlayedSFX = true;
                }
                
                anim.SetBool("Jump", false);
                anim.SetBool("Skating", false);
                anim.SetBool("Hit", true);
            }
        }

        if (hitDelay <= 0.0)
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;

            hasPlayedSFX = false;
            isHit = false;

            anim.SetBool("Skating", true);
            anim.SetBool("Hit", false);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            hitDelay = 1;

            

            deathCounter++;

            if (deathCounter <= 2)
            {
                isHit = true;
            }
            


            /* Het spel zoekt voor een GameObject, die in de editor een tag genaamd "Obstacle" heeft. Dit duid aan dat het een obstakel is.
             * de deathCounter var houdt bij hoevaak je geraakt bent door een obstakel.
             * Wanneer de speler in aanraking komt met het GameObject, telt de death Counter op met één keer.
             * Na drie keer geraakt te worden door een obstakel, wordt de skate animatie stopgezet, om vervolgens de death animatie af te spelen.
             * GAME OVER!
             */
        }
    }
}
