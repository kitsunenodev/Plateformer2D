using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundEffectManager.instance.soundEffectSource.PlayOneShot(sound);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Inventory.instance.AddCoins(1);
            CurrentSceneManger.instance.coinsPickedUp++;
            Destroy(this.gameObject,sound.length);
        }
    }
}
