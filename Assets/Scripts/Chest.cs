using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    
    private TextMeshProUGUI interactUI;
    
    private bool isInRange;

    public AudioClip sound;

    public int TreasureAmount;

    [SerializeField] 
    private Animator animator;
    
    // Start is called before the first frame update
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("TextUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
        
    }

    private void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        GetComponent<BoxCollider2D>().enabled = false;
        Inventory.instance.AddCoins(TreasureAmount);
        SoundEffectManager.instance.soundEffectSource.PlayOneShot(sound);
        interactUI.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
            interactUI.SetText("PRESS E TO OPEN THE CHEST");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
