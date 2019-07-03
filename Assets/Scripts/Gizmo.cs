﻿
using System.Collections;
using UnityEngine;



public class Gizmo : MonoBehaviour {

    // a lot of this script has been taken away from the camecontrol, 
    //it uses the same script practically, just slight variations of the offset, right and left.
    public Transform Target;
    public float speed = 0.125f;
    public Vector3 offright;
    public Vector3 offleft;


    // shoot variables
    public GameObject laser;
    public float laserspeed;
    
    // this one could've just stayed facingRight, but it's Gizmo that's doing it.
    public bool GizmofacingRight;
    // why does Gizmo have HP, he doesn't even die, he's a robot dog.
    private float HP = 100;

    private void Start()
    {
        GizmofacingRight = true;
        
    }
    void FixedUpdate()
    {

        // get the horizontal axis and call the flip.
        float Hory = Input.GetAxis("Hor");
        Flip(Hory);

        // still part of the cameracontrol, it just follows the targer, in this case the player.
        // original plan was a pathfoinder, but it didn't work, waste of 5 hours work.
        if (scriptSpeler.facingRight)
        {
            Vector3 desiredPos = Target.position + offright;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, 0.05f);
            transform.position = smoothPos;

        }
        else
        {
            Vector3 desiredPos = Target.position + offleft;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, 0.05f);
            transform.position = smoothPos;
        }

        // shooting taken from SpaceInvaders
        if (Input.GetKeyDown(KeyCode.Space))
        {
            offright.x = 2;
            InvokeRepeating("Fire", 0.000001f, 0.5f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            offright.x = -1;
            CancelInvoke("Fire");
        }

    }
    // to find the player after deletion.
    public void Update()
    {
        if (Target == null)
        {
            FindPlayer(true);
            return;
        }
    }

    public void FindPlayer(bool findSwitch)
    {
        if (findSwitch == true)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
            {
                Target = searchResult.transform;
            }
            findSwitch = false;
        }

    }
    
    // shooting part still take from the SpaceInvaders.
    void Fire()
    {
        Vector3 startPositie = transform.position + new Vector3(0, 0, 0);
        GameObject Straal = Instantiate(laser, startPositie, Quaternion.identity) as GameObject;
        if (GizmofacingRight)
        {
            Straal.GetComponent<Rigidbody2D>().velocity = new Vector3(6, 0, 0);
        }
        else {
            Straal.GetComponent<Rigidbody2D>().velocity = new Vector3(-6, 0, 0);
        }
    }

    // wait, Gizmo can die? by missiles?
    // so this is a useless part, it's just there
    void OnTriggerEnter2D(Collider2D col)
    {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
            missile.Hit();
        }
    }

    // flippin perfect
    private void Flip(float Hory)
    {
        if (Hory > 0 && !GizmofacingRight || Hory < 0 && GizmofacingRight)
        {
            GizmofacingRight = !GizmofacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}