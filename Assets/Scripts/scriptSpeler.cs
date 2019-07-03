using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSpeler : MonoBehaviour {
        
    // basic speed and rigidbody
    public float speed;
    private Rigidbody2D player;

    
    public static bool facingRight;
    
    public static float HP = 100;

    // collectables, the character you collect, the converting and the collected gameobject.
    private int collected;
    private char letter;
    string convert;
    private GameObject invent;

    private bool jump = false;
    bool grounded = false;   
	float jumpForce = 250f;

    // menu that pops up if you hit the door
    public GameObject EndMenuUI;

    // sounds
    AudioSource Ping;// the sound of collected collectable

	void Start () {
        HP = 100; // it's also in start so when you die and respawn it gets reset.
        facingRight = true; // you start by looking right
        // getting needed components
        player = GetComponent<Rigidbody2D>();
        Ping = GetComponent<AudioSource>();
	}

	void Update () {
	    // if statement to jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true || Input.GetKeyDown(KeyCode.W) && grounded == true) {
			jump = true;
		}
        // print(HP); // to check if health works
        if(HP <= 0)
        {
            GameMaster.KillPlayer(this);
        }
	}


	void FixedUpdate () {
		if (jump == true) {
			player.AddForce (new Vector2 (0f, jumpForce)); // how to go up, wen jumping
			jump = false; // so if this gets deleted you can fly, well at least you go up and up and up.
			grounded = false; // I don't want a double jump.
		}
        float Hory = Input.GetAxis("Hor"); // to get the horzontal axis, so you get the way you walk to get the way you look
        HandleMovement(Hory); // and to do the walk
        Flip(Hory); // and to do the flip
	}

    private void HandleMovement(float Hory)
    {
        player.velocity = new Vector2(Hory * speed, player.velocity.y);
    }

	public void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}
        
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if(coll.gameObject.tag == "coll") // collider to collect the collectees
        {
            Ping.Play();

            // the random collectees, and changing color of those.
            collected = Random.Range(0, 25);
            letter = (char)('a' + collected);
            Debug.Log(letter);
            convert = "" + letter;
            invent = GameObject.Find(convert);
            Material mater;
            mater = invent.GetComponent<Renderer>().material;
            mater.color = Color.yellow;
        }
        if(coll.gameObject.tag == "End") // collider to get to the bossfight.
        {
            Door();
        }
    }
    
    // the flip function
    private void Flip(float Hory)
    {
        if (Hory > 0 && !facingRight || Hory < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    // the door function, it places the menu active to proceed to the 'end'.
    void Door()
    {
        EndMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

}