using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;

    public SpriteRenderer sprRenderer;

    public bool isInvincible = false;

    public float invincibilityFlashDelay;

    public float invincibilityTime;

    public static PlayerHealth instance;
    
    public AudioClip hitSound;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There are more than one instance of the player in the scene");
            return;
            
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            SoundEffectManager.instance.soundEffectSource.PlayOneShot(hitSound);
            healthBar.setHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.playerRigidbody.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerRigidbody.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);

    }

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount ) > maxHealth )
        {
            currentHealth = maxHealth;

        }
        else
        {
            currentHealth += amount;
        }
        healthBar.setHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            sprRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            sprRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);

        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
