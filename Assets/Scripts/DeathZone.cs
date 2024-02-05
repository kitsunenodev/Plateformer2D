using System;
using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(other));

        }
    }

    private IEnumerator ReplacePlayer(Collider2D other)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        other.transform.position = CurrentSceneManger.instance.respawnPoint;
    }
}
