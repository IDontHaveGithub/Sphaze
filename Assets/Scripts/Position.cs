using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is just to show the position, it's a child of the spawns, so positions to spawnin, taken from the spaceInvaders.
public class Position : MonoBehaviour {

    public int chosen = 0;

    void OnDrawGizmosSelected() {
        Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
        Gizmos.color = colors[chosen];
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
