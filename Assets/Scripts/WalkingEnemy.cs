using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour {

    // speed object
    public int speed;
    // how much damage dealt
    private float Dmg = 10f;
    // how much health itself
    public float HP = 200;
    

    // it's just to turn the sprite, cause i'm to lazy to turn it in real, also calling the coroutine.
    void Start () {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        StartCoroutine(MovementHandle());

        
    }
	
	// just the basic movement
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }

    // every two seconds, walk the other way and flip.
    IEnumerator MovementHandle ()
    {
        yield return new WaitForSeconds(2);
        speed = -speed;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        StartCoroutine(MovementHandle());
    } 

    // collision to do damage.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scriptSpeler.HP = scriptSpeler.HP - Dmg;
            
        }
    }

    // collision to get damage and die
    void OnTriggerEnter2D(Collider2D col)
    {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Score.points += 30f;
                Destroy(gameObject);
            }
            missile.Hit();
        }
    }

}
