using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // another form the SpaceInvaders
    // SpaceInvaders MVP!!
    public float schade = 20f;
    public float GetDamage()
    {
        return schade;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

	void Update () {
		Destroy(gameObject, 4);
	}
}
