using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InventoryHolder: MonoBehaviour
{
    public static InventoryHolder instance;
    protected Inventory inventory;
    [SerializeField]
    private ItemData[] itemsData;
    public Inventory Inventory => inventory;
    public Transform itemContent;
    public Transform itemInfo;
    public Image weaponSprite;
    public Image secWeaponSprite;
    public Image secWeaponBSprite;
    public GameObject inventoryItem;
    public RectTransform messageBox;
    public TMP_Text messageText;
    private void Awake() {
        Inventory.instance = new Inventory(itemsData, itemContent, inventoryItem, itemInfo, weaponSprite, secWeaponSprite, secWeaponBSprite, messageBox, messageText);
        Inventory.instance.StartInventoryUI();
    }
}
