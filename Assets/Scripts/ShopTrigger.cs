using TMPro;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private bool isInrange;

    public string PNJName;
    public Item[] itemsToSell;

    private TextMeshProUGUI interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("TextUI").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isInrange && Input.GetKeyDown(KeyCode.E))
        {
            interactUI.enabled = false;
            if (ShopManager.instance.animator.GetBool("isOpen"))
            {
                ShopManager.instance.CloseShop();
            }
            else
            {
               ShopManager.instance.OpenShop(itemsToSell,PNJName); 
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = true;
            interactUI.enabled = true;
            interactUI.SetText("PRESS E TO TALK");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
}
