using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is just to show the position, it's a child of the spawns, so positions to spawnin, taken from the spaceInvaders.
public class Position : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
