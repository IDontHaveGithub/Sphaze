using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // how much damage dealt
    private float Dmg = 10f;
    // how much health itself
    public float HP = 200;
    //amount of points if killed
    public float point = 30f;


    // collision to damage the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scriptSpeler.HP = scriptSpeler.HP - Dmg;
        }
    }

    // collision to get damage and die.
    void OnTriggerEnter2D(Collider2D col)
    {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Score.points += point;
                Destroy(gameObject);
            }

        }
    }

}
