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
    private float hitDelay = 0.5f;
	//floats

	//strings
	[SerializeField]
	private string pickUps;
	//strings

	//int
	private int jumps = 0;
	private int seconds = 3;
    private int hitCounter = 0;
	public int deathCounter = 0;
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
    [SerializeField]
    private AudioClip shieldSFX;
    [SerializeField]
    private AudioClip sodaSFX;
    [SerializeField]
    private AudioClip clockSFX;

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

	void Update () 
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

        Crouch();
		

		
	}

    void Crouch()
    {
        //CROUCHING
        if (Input.GetKeyDown(KeyCode.Z) && grounded == true)
        {
            anim.SetBool("Skating", false);
            anim.SetBool("Crouch", true);
        }

        else if (Input.GetKeyUp(KeyCode.Z) && grounded == true)
        {
            anim.SetBool("Crouch", false);
            anim.SetBool("Skating", true);
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
            goSign = false;

            anim.SetBool("Hit", false);
            anim.SetBool("Skating", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Death", true);

            if (!hasPlayedSFX)
            {
                deathSFX.Play();
                hasPlayedSFX = true;
            }
            

            //Time.timeScale -= Time.deltaTime;
            //Time.timescale is standaard 1. 
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
           
            hitDelay -= Time.deltaTime;

            if (hitDelay <= 0.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0.5f);

                if(!hasPlayedSFX)
                {
                    hitSFX.Play();
                    hasPlayedSFX = true;
                }
                
                anim.SetBool("Jump", false);
                anim.SetBool("Skating", false);
                anim.SetBool("Hit", true);

                if (!grounded)
                {
                    anim.SetBool("Jump", false);
                    anim.SetBool("Hit", true);
                }
            }
        }

        if (hitDelay <= 0.0)
        {
            hasPlayedSFX = false;
            isHit = false;

            anim.SetBool("Hit", false);
            //anim.SetBool("Skating", true);
           
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Pickup_Shield")
        {
            AudioSource.PlayClipAtPoint(shieldSFX, transform.position);
        }

        else if (other.gameObject.tag == "Pickup_Soda")
        {
            AudioSource.PlayClipAtPoint(sodaSFX, transform.position);
        }

        else if (other.gameObject.tag == "Pickup_Clock")
        {
            AudioSource.PlayClipAtPoint(clockSFX, transform.position);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            hitDelay = 0.5f;

            

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
