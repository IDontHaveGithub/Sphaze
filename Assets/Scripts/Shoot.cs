using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    //give amount of damage bullet does and return
    public float schade = 20f;

    public float GetDamage()
    {
        return schade;
    }

    //destroy bullet after 2 seconds
    void Update()
    {
        Destroy(gameObject, 2);
    }
}
