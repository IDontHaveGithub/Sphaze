using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollScript : MonoBehaviour {

    // get the sprite in gameobject
    public GameObject LittleLight;
    public static int lightCount;
    

	// Use this for initialization
	void Start () {
        //there it is, the wittlewhitey
        LittleLight = GetComponent<GameObject>();
        // all objects add one to the count.
        lightCount++;
	}
	
	// Update is called once per frame
	void Update () {
        //check in console if you have them all.
		if(lightCount <= 0f)
        {
            print("You got 'em all!");
        }
	}

    // if hit by player, get points, destroy object and lose one on lightCount
    void OnTriggerEnter2D(Collider2D player)
    {
        
        if (player.gameObject.tag == "Player")
        {
            
            Score.points += 10f;
            Destroy(gameObject);
            lightCount--;
        }
    }
}
