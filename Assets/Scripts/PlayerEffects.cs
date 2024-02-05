using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public void Addspeed(int amount, float duration)
    {
        PlayerMovement.instance.moveSpeed += amount;
        StartCoroutine(RemoveSpeed(amount, duration));
    }

    private IEnumerator RemoveSpeed(int amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerMovement.instance.moveSpeed -= amount;
    }
}
