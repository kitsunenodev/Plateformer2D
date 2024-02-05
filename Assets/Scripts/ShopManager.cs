using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
    public TextMeshProUGUI PNJNameText;
    public Animator animator;
    public GameObject sellButtonPrefab;
    public Transform sellButtonParent;
    

    public static ShopManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("there is more than one instance of ShopManager in the scene");
            return;
        }

        instance = this;
    }

    public void OpenShop(Item[] items, string PNJName)
    {
        
        PNJNameText.text = PNJName;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen", true);

    }

    void UpdateItemsToSell(Item[] items)
    {
        for (int i = 0; i < sellButtonParent.childCount; i++)
        {
            Destroy(sellButtonParent.GetChild(i).gameObject);
        }
        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(sellButtonPrefab, sellButtonParent,true);
            Debug.Log(button);
            SellItemButton buttonScript = button.GetComponent<SellItemButton>();
            buttonScript.itemName.text = items[i].nameItem;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();
            buttonScript.item = items[i];
            
            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); });
        }
        
    }
    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }
}
