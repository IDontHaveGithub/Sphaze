using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    // so I made this before the respawnign of the space invaders got put on the internet, geeze louise, it was hard work finding one you know.
    // it wasn't even up to date, so I had to read four pages of comments to find the answer in there.

    public static GameMaster gm;
	// Use this for initialization
	void Start () {
		if(gm == null)
        {
            gm = this;

        }
	}

    public Transform playerPrefab;
    public Transform spawnPoint;

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

    }
	
    public static void KillPlayer(scriptSpeler player)
    {
        Destroy(player.gameObject);
        gm.RespawnPlayer();

    }
	// Update is called once per frame
	void Update () {
		
	}
}
