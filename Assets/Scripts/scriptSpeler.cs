using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSpeler : MonoBehaviour
{

    private float speed = 3f;
    private float jumpForce = 250f;


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

    private float HP = 100;

    void Start()
    {
        HP = 100; // it's also in start so when you die and respawn it gets reset.
        // getting needed components
        player = GetComponent<Rigidbody2D>();
        Ping = GetComponent<AudioSource>();
    }

    void Update()
    {
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
    }


    void FixedUpdate()
    {
        if (jump == true)
        {
            player.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            grounded = false;
        }
        float Hory = Input.GetAxis("Hor");
        HandleMovement(Hory);
    }

    private void HandleMovement(float Hory)
    {
        player.velocity = new Vector2(Hory * speed, player.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "coll") // collider to collect the collectees
        {
            Ping.Play();

            // the random collectees, and changing color of those.
            collected = Random.Range(0, 25);
            letter = (char)('a' + collected);
            Debug.Log(letter);
            convert = "" + letter;
            inventory = GameObject.Find(convert);
            Material mater;
            mater = inventory.GetComponent<Renderer>().material;
            mater.color = Color.yellow;
        }
        if (coll.gameObject.tag == "End" /* && all the collectables */) // collider to get to the bossfight.
        {
            Door();
        }
    }

    // the flip function
    private void Flip(bool facingRight)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;
        if (true)
        {
            facingRight = !facingRight;

            //change scale to flip image
        }
    }

    bool faceRight()
    {
        float Horizontal = Input.GetAxis("Hor");
        if (Horizontal > 0)
            return true;
        else if(Horizontal < 0)
        {
            return false;
        }
        else { return true; }
    }

    // the door function, it places the menu active to proceed to the 'end'.
    void Door()
    {
        EndMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;
    }

}