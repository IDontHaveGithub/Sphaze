using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkingEnemy : Enemy {

    // speed object
    public int speed;
   
    // for now a flipping sprite, later add animations
    void Start () {
        
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;

        StartCoroutine(MovementHandle());
    }
	
	// just the basic movement
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // every two seconds, walk the other way and flip.
    IEnumerator MovementHandle ()
    {
        yield return new WaitForSeconds(2);

        speed = -speed;

        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;

        StartCoroutine(MovementHandle());
    }
    
}
