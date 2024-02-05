using System;
using System.Linq;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance of LoadAndSaveData in the scene");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount",0);
        Inventory.instance.UpdateTextUI();

        int currentHealth = PlayerPrefs.GetInt("currentHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.setHealth(currentHealth);
        
        string[] itemsSaves = PlayerPrefs.GetString("InventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaves.Length; i++)
        {
            if (itemsSaves[i] != "")
            {
                int id = int.Parse(itemsSaves[i]);
                Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }
        Inventory.instance.UpdateInventoryUI();
    }

    public void SaveData()
    {
        if (CurrentSceneManger.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached",1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManger.instance.levelToUnlock);
        }
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("currentHealth", PlayerHealth.instance.currentHealth);

        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("InventoryItems", itemsInInventory);

        string[] itemsSaves = itemsInInventory.Split(',');
    }
}
