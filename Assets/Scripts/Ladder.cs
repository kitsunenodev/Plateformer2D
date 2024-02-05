
using System;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private BoxCollider2D PlateformCollider;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
        PlateformCollider = colliders[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.isClimbing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GoThrough();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.isClimbing = false;
            PlateformCollider.isTrigger = false;
        }
    }

    private void GoThrough()
    {
        if (playerMovement.isClimbing && playerMovement.GetVerticalMovement() != 0)
        {
            PlateformCollider.isTrigger = true;
        }
    }
}
