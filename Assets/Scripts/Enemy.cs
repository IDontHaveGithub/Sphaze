using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float point;
    public float Dmg;
    
    // collision to damage the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scriptSpeler player = collision.gameObject.GetComponent<scriptSpeler>();
        if (player)
        {
            player.TakeDamage(Dmg);
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
