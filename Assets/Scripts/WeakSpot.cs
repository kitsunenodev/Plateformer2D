using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject parent;

    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundEffectManager.instance.soundEffectSource.PlayOneShot(sound);
            parent.gameObject.SetActive(false);
            Destroy(parent, sound.length);
        }
    }
}
