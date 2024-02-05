using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;
    public static Inventory instance;
    private int contentCurrentIndex = 0;

    public Image itemImageUI;
    public TextMeshProUGUI itemNameUI;
    public Sprite emptyItemImage;

    public List<Item> content = new List<Item>();

    public PlayerEffects effects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Inventory in the scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void UpdateTextUI()
    {
        
              coinsCountText.text = coinsCount.ToString();
        
      
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count -1)
        {
            contentCurrentIndex = 0;
        }
        
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        Item currenItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currenItem.HP_heal);
        effects.Addspeed(currenItem.speedBoost,currenItem.SpeedDuration);
        content.Remove(currenItem);
        GetNextItem();
        UpdateInventoryUI();

    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        { 
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;

        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }
}
