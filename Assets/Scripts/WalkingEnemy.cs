using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WalkingEnemy : MonoBehaviour {

    // speed object
    public int speed;
   
    // it's just to turn the sprite, cause i'm to lazy to turn it in real, also calling the coroutine.
    void Start () {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
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
        theScale.x *= -1;
        transform.localScale = theScale;
        StartCoroutine(MovementHandle());
    }
    
}
