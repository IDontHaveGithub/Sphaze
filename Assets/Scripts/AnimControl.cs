using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour {

    // this script isn't actually being used at the moment,  but it's for the player
    // I don't really feel like actually doing it tho.
    // but I'll leave it here for , idk,  maybe I will do it anyway.

	public Animator anim;
    float Hory = Input.GetAxis("Hor");

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>() ;
	}
	
	// Update is called once per frame
	void Update () {
        if (Hory != 0)
        {

        }
	}
}
