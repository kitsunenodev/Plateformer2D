using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public AudioClip pickUpSound;
    public SpriteRenderer sprRenderer;
    public BoxCollider2D itemCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.content.Add(item);
            Inventory.instance.UpdateInventoryUI();
            sprRenderer.enabled = false;
            itemCollider.enabled = false;
            SoundEffectManager.instance.soundEffectSource.PlayOneShot(pickUpSound);
            Destroy(gameObject, pickUpSound.length);
        }
    }
}
