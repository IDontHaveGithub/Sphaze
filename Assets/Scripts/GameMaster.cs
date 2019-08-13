using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster instance;

    public Transform playerPrefab;
    public Transform spawnPoint;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(scriptSpeler player)
    {
        Destroy(player.gameObject);
        instance.RespawnPlayer();
    }
}
