    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnemy : MonoBehaviour {

    // a lot has been taken out of this script, scince it doesn't work with the animator that's also on it, 
    // maybe it will be erased later, or the animator will go, or get changed

//    public Sprite[] flower;
//   private int sprite;
//    private float distance;
//    GameObject player;
    private float Dmg = 3f;
    public float HP = 50;

    public float points = 20f;

    // Use this for initialization
//    void Start () {
//        GetComponent<SpriteRenderer>().sprite = flower[sprite];
//        player = GameObject.Find("character");
//        distance = transform.position.x - player.transform.position.x;
//    }
	

//	void Update () {
//        distance = transform.position.x - player.transform.position.x;
//        if (distance <= 1 && distance >= -1)
//        {
//            sprite = 1;
//            GetComponent<SpriteRenderer>().sprite = flower[sprite];
//        }
//       else
//        {
//            sprite = 0;
//            GetComponent<SpriteRenderer>().sprite = flower[sprite];
//       }
//	}

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
                Score.points += 20f;
                Destroy(gameObject);
            }
            missile.Hit(this.gameObject);
        }
    }
}
