using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoThroughPlateform : MonoBehaviour
{
    private PlayerMovement player;
    private BoxCollider2D Platformcollider;
    
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Platformcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (player.groundCheck.position.y < transform.position.y && !Platformcollider.isTrigger)
        {
            Platformcollider.isTrigger = true;
        }
        if (player.groundCheck.position.y > transform.position.y && Platformcollider.isTrigger)
        {
            Platformcollider.isTrigger = false;
        }
    }
}
