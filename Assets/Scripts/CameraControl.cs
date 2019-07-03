using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // who to follow
    private Transform Target;

    // how fast to follow
    public float speed = 0.125f;

    // only if you don't want the camera to be centered, otherwise just 0.
    public Vector3 offright;
    public Vector3 offleft;

    void FixedUpdate()
    {
     
        // to get the not centered right, when you look the other way.
        if (scriptSpeler.facingRight)
        {
            Vector3 desiredPos = Target.position + offright;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, 0.05f);
            transform.position = smoothPos;
        }
        else
        {
            Vector3 desiredPos = Target.position + offleft;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, 0.05f);
            transform.position = smoothPos;
        }

    }

    //constantly check for player.
    public void Update()
    {
        if (Target == null)
        {
            FindPlayer(true);
            return;
        }
    }

    // when the player dies, it gets respawned, but the player object is gone for a bit, this way you'll find the player again.
    public void FindPlayer(bool findSwitch)
    {
        if (findSwitch == true)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
            {
                Target = searchResult.transform;
            }
            findSwitch = false;
        }

    }
}
