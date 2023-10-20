using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class ItemData : ScriptableObject
{
    public string id;
    public int quantityLimit;
    public string itemName;
    public int value;
    public Sprite icon;
    [TextArea(4,4)]
    public string description;
    public ItemType itemType;
    public enum ItemType
    {
        healthPotion,
        magicPotion,
        fullPotion,
        key,
        mainWeapon,
        secondaryWeapon,
        panacea
    }
    public SecondaryWeapon secondaryWeapon;
}
