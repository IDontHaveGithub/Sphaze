using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour {

    // random floats to get random movement.
    private int ranx;
    private int rany;

    // how much damage when touching player.
    private float Dmg = 5f;
    public float HP = 150;

    public float points = 40f;

	// nothing to initiate but moving.
	void Start () {
        StartCoroutine(MovementHandle());
    }
	
	// this is the movement itself
	void Update () {
        transform.Translate(ranx *Time.deltaTime, rany * Time.deltaTime, 0);
    }

    // the random int, for random movement, with delay to choose again.
    IEnumerator MovementHandle()
    {
        ranx = Random.Range(-4, 4);
        rany = Random.Range(-4, 4);

        yield return new WaitForSeconds(2f);
        StartCoroutine(MovementHandle());
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // just so it doesn't glitch through the colliders
        rany = -rany;
        ranx = -ranx;
        // if player gets hit, it gives damage.
        if (collision.gameObject.tag == "Player")
        {
            scriptSpeler.HP = scriptSpeler.HP - Dmg;
        }
    }

    // collider for the bullets of Gizmo, the dog, so they can actually die.
    void OnTriggerEnter2D(Collider2D col)
    {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Score.points += 40f;
                Destroy(gameObject);
                
            }
            missile.Hit(this.gameObject);
        }
    }

}
