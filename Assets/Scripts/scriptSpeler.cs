﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSpeler : MonoBehaviour
{

    private float Horizontal;
    private float speed = 3f;
    private float jumpForce = 250f;
    private float HP = 100;

    // FIXME: why are the collectables done in the player script?
    private int collected;
    private char letter;
    private string convert;

    public GameObject EndMenuUI; //FIXME: this prefab is broken
    private GameObject inventory;

    private bool jump = false;
    private bool grounded = false;

    private Rigidbody2D player;
    private AudioSource Ping;// the sound of collected collectable



    void Start()
    {
        HP = 100; // it's also in start so when you die and respawn it gets reset.
        // getting needed components
        player = GetComponent<Rigidbody2D>();
        Ping = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Hor");
        HandleMovement(Horizontal);
        
        // if statement to jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true || Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            jump = true;
        }
        // print(HP); // to check if health works
        if (HP <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        //reset if stuck in the ground.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HP = 0;
        }

        if (faceRight())
        {
            Flip();
        }
    }


    void FixedUpdate()
    {
        if (jump == true)
        {
            player.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            grounded = false;
        }
        
    }

    // the flip function
    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;
    }

    bool faceRight()
    {
        if (Horizontal >= 0)
            return true;
        else
        {
            return false;
        }
    }

    private void HandleMovement(float Hory)
    {
        player.velocity = new Vector2(Hory * speed, player.velocity.y);
    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    
    //TODO: make it so this part is it's own script 
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "coll") // collider to collect the collectees
        {
            Ping.Play();

            // the random collectables, and changing color of those. //FIXME: plz
            collected = Random.Range(0, 25);
            letter = (char)('a' + collected);
            Debug.Log(letter);
            convert = "" + letter;
            inventory = GameObject.Find(convert);

            inventory.GetComponent<Renderer>().material.color = Color.yellow;
        }
        if (coll.gameObject.tag == "End" /* && all the collectables */) // collider to get to the bossfight.
        {
            Door();
        }
    }

    //FIXME: should be done by dedicated script
    // the door function, it places the menu active to proceed to the 'end'.
    void Door()
    {
        EndMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }


}