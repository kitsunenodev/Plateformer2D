using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CurrentSceneManger.instance.respawnPoint = transform.position;
            anim.SetBool("IsActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSpawn"))
        {
            anim.SetBool("IsActive", false);
        }
    }
}
