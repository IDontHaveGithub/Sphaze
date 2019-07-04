using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // this is a basic score regime, it doesn't save and has to be put in parent canvas
    public Text score;
    public static float points;

	// get the textpart
	void Start () {
        score = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + points;
	}
}

//fun fact: You can actuallly die, but, if you do, you respawn, there is no escaping this hell that was supposed to be space, but isn't.
