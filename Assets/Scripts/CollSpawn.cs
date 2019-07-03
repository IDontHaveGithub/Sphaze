using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollSpawn : MonoBehaviour {

	// get the object
	public GameObject SpawnStuff;
    
    // it takes 2 sec after all of the colls have been got to respawn.... 
    //bit too much darling, maybe spawn before they're all gone, 
    //so you dont have to search for that one left?

        // nehhhh
    public float spawnDelay = 2f;


    // You have an instant spawning now, but maybe you want a rando spawning of 5 that spawns others if you get one after a while.
    // so spawning after time and random places of the positions, check out, how to, plz.


    // yes I know how to now, give me a sec.
    void Start () {
        
        // first spawning
			foreach (Transform child in transform) {
				GameObject spawn = Instantiate (SpawnStuff, child.transform.position, Quaternion.identity) as GameObject;
				spawn.transform.parent = child;
			}

    }

    private void Update()
    {
        // how to respawn, first call function... >> go to said function >>
        if (AllDead())
        {
            SpawnAgain();
        }
    }

    bool AllDead()
    {
        foreach (Transform childpositionGameObject in transform)
        {
            if (childpositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform childpositionGameObject in transform)
        {
            if (childpositionGameObject.childCount == 0)
            {
                return childpositionGameObject;
            }
        }
        return null;
    }

    // Respawn!  >nailed it<
    // turns out, after carefully testing, it doesn't actually respawn, no error, no problems, but no respawn...
    // I'm sad now...
    // nevermind, the comment that was saying I had them all missed a couple, it works, it's perfect.
    void SpawnAgain()
    {
        Transform freePosition = NextFreePosition();// one function up
        if (freePosition)
        {
            GameObject spawn = Instantiate(SpawnStuff, freePosition.position, Quaternion.identity) as GameObject;
            spawn.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnAgain", spawnDelay);
        }
    }

}