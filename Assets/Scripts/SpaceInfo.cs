using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceInfo : MonoBehaviour {

    /// this script is getting put on every space ninja throughout the level, just to give tips, or warnings.
    /// they're practically to tell you about the bugs, before you see them yourself ;p
    /// until it gets fixed
    public GameObject InfoSpace;

    private void Start()
    {
        InfoSpace.SetActive(false);
        
    }

    // so simple, but no bread.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InfoSpace.SetActive(true);
            Score.points++; //2019 update, good to use for pointwhores...
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InfoSpace.SetActive(false);
        }
    }
}
