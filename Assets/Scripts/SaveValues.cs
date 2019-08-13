using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

//FIXME: this entire script is fucked
public class SaveValues : MonoBehaviour {
    // Made by Eric, cause Lotte was too lazy, except the comments, that was Lotte, cause Eric forgot.

    // the amount of fields, all given inside the inspector
	public InputField text1, text2, text3, text4;
	
    // and the result, for some reason not just a text field.
	public Text result1;

    // why aren't the inputfield inside of an array, I mean, 
    // I didn't make this so I won't change work without asking, but... just asking...
	public static List<string> words = new List<string>();


    // words getting added to the string where they will later be used inside of the story or 'the result'.
	public void AddWords(){
		words.Add (text1.text);
		words.Add (text2.text);
		words.Add (text3.text);
		SceneManager.LoadScene ("MadLibz2");
	}
    // same
	public void AddWords2(){
		words.Add (text1.text);
		words.Add (text2.text);
		words.Add (text3.text);
		words.Add (text4.text);
		SceneManager.LoadScene ("Results");
	}

    // 'the result' aka the one story we could come up with in the limited time left after the website.(that didn't even get finished...
	void Update(){
		result1.text = "The " + words[0] + " millionaire came home one late night to find his " + words [1] 
            + " " + words [2] + " passed out on the floor in the livingroom! And boy was he " + words[3] 
            + "! He didn't let it get to him though. He had expected this was going on while he was away " +
            "and had planned something for just this case. He grabbed a " + words[4] + ", filled it with lukewarm " 
            + words[5] + ", and while his " + words[1] + " was still KO he put his " + words[1] + "'s " + words[6] 
            + " in the " + words[4] + ". HA! That'll teach 'em.";

	}
}






























// There is no use for an ending so early in a game, but hey, I don't feel like working on this project any longer than this, for at least 6 months.