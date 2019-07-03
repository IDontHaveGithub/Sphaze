using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollScript : MonoBehaviour {

    // get the sprite in gameobject
    public GameObject LittleLight;
    // let it count, let it count
    public static int lightCount;
    

	// Use this for initialization
	void Start () {
        //there it is, the wittlewhitey
        LittleLight = GetComponent<GameObject>();
        // i actually frogot how the song went on...
        lightCount++;
	}
	
	// Update is called once per frame
	void Update () {
        // y u no work?
        // it misses a couple and goes around saying I have em all 
        // but noooooo
        // tch.
		if(lightCount <= 0f)
        {
            print("You got 'em all!");
        }
	}

    // or are you the one. Aren't you counting em right, am I touching you indecently? Is that it?
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
