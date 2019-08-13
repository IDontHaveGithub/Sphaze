using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollScript : MonoBehaviour
{

    // get the sprite in gameobject
    public GameObject LittleLight;
    public static int lightCount;


    // Use this for initialization
    void Start()
    {
        LittleLight = GetComponent<GameObject>();
        lightCount++; //for every initialization of Collscript a light gets added
    }

    // Update is called once per frame
    void Update()
    {
        //check in console if you have them all.
        if (lightCount <= 0f)
        {
            print("You got 'em all!");
        }
    }

    // if hit by player, get points, destroy object and lose one on lightCount
    void OnTriggerEnter2D(Collider2D col)
    {
        scriptSpeler player = col.GetComponent<scriptSpeler>();
        if (player)
        {
            Score.points += 10f;
            Destroy(gameObject);
            lightCount--;
        }
    }
}
