using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollSpawn : MonoBehaviour {
    
    public float spawnDelay = 2f;

    public GameObject SpawnStuff;

    void Start()
    {
        // initial spawning
        foreach (Transform child in transform)
        {
            GameObject spawn = Instantiate(SpawnStuff, child.transform.position, Quaternion.identity) as GameObject;
            spawn.transform.parent = child;
        }
    }

    private void Update()
    {
        // continiously check if everything is dead then call spawn
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

    //check if the next position is free to spawn in
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

    // Respawn
    void SpawnAgain()
    {
        Transform freePosition = NextFreePosition();
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