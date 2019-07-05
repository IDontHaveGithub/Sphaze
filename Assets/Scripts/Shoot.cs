using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    // another from the SpaceInvaders
    // SpaceInvaders MVP!!
    public float schade = 20f;
    public float GetDamage()
    {
        return schade;
    }

    public static void Hit(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Destroy(gameObject, 4);
    }
}
