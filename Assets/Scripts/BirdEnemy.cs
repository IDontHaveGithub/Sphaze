using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour {

    // random floats to get random movement.
    private int ranx;
    private int rany;


	// nothing to initiate but moving.
	void Start () {
        StartCoroutine(MovementHandle());
    }
	
	// this is the movement itself
	void Update () {
        transform.Translate(ranx *Time.deltaTime, rany * Time.deltaTime, 0);
    }

    // the random int, for random movement, with delay to choose again.
    IEnumerator MovementHandle()
    {
        ranx = Random.Range(-4, 4);
        rany = Random.Range(-4, 4);

        yield return new WaitForSeconds(2f);
        StartCoroutine(MovementHandle());
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // just so it doesn't glitch through the colliders
        rany = -rany;
        ranx = -ranx;
       
    }

}
