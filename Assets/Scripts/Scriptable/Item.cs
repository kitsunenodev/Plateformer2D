using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;

    public string nameItem;

    public string description;

    public Sprite image;

    public int HP_heal;

    public int speedBoost;

    public float SpeedDuration;

    public int price;


}
