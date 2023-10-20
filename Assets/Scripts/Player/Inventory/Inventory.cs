using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory: MonoBehaviour
{
    public static Inventory instance;
    public Dictionary<string, InventorySlot> inventorySlots;
    public Dictionary<string, InventorySlot> GetInventorySlots => inventorySlots;
    public int GetInventorySize => GetInventorySlots.Count;
    
    private string selectedItemID;
    private GameObject selectedItemObject;
    public Transform itemContent;
    public Transform itemInfo;
    public GameObject inventoryItem;
    public Image weaponSprite;
    public Image secWeaponSprite;
    public Image secWeaponBSprite;
    public RectTransform messageBox;
    public TMP_Text messageText;

    private bool hasSelected = false;

    public Inventory(ItemData[] items, Transform contentUI, GameObject itemUI, Transform infoPane, Image mainSprite, Image secSprite, Image secBSprite, RectTransform msgBox, TMP_Text msgText){
        inventorySlots = new Dictionary<string, InventorySlot>();
        for(int i = 0; i < items.Length; i++){
            inventorySlots.Add(items[i].id, new InventorySlot(items[i], (int) items[i].quantityLimit));
        }
        this.itemContent = contentUI;
        this.inventoryItem = itemUI;
        this.itemInfo = infoPane;
        this.weaponSprite = mainSprite;
        this.secWeaponSprite = secSprite;
        this.secWeaponBSprite = secBSprite;
        this.messageBox = msgBox;
        this.messageText = msgText;
    }

    public bool AddToInventory(ItemData itemData, int amount){
        bool result = inventorySlots[itemData.id].AddItem(amount);
        return result;
    }
    public bool AddToInventory(string id, int amount)
    {
        bool result = inventorySlots[id].AddItem(amount);
        return result;
    }
    public bool HasItem(string id)
    {
        if(inventorySlots[id].quantity > 0)
            return true ;
        return false;
    }
    public void SetMessage(ItemData itemData){
        messageBox.gameObject.SetActive(true);
        messageText.text = string.Format("You got {0}!", itemData.itemName);
    }
    public void StartInventoryUI(){
        Inventory.instance.GetSelectedItem();
        if(Inventory.instance.selectedItemID != null && Inventory.instance.GetInventorySlots[Inventory.instance.selectedItemID].quantity <= 0){
            hasSelected = false;
        }
        foreach(InventorySlot itemSlot in Inventory.instance.GetInventorySlots.Values){
            if(itemSlot.quantity > 0){
                var itemUI = Instantiate(inventoryItem, itemContent);
            
                var itemUIText = itemUI.transform.Find("Text").GetComponent<TMP_Text>();
                var itemUISprite = itemUI.transform.Find("Sprite").GetComponent<Image>();
                var itemUIButton = itemUI.GetComponent<InventoryButton>();

                itemUISprite.sprite = itemSlot.ItemData.icon;
                itemUIText.text = itemSlot.quantity.ToString();
                itemUIButton.itemData = itemSlot.itemData;

                if(!Inventory.instance.hasSelected){

                    Inventory.instance.hasSelected = true;
                    Inventory.instance.selectedItemID = itemUIButton.itemData.id;
                    Inventory.instance.selectedItemObject = itemUI;
                    EventSystem.current.SetSelectedGameObject(itemUI);                    
                }else if(itemUIButton.itemData.id == Inventory.instance.selectedItemID){
                    EventSystem.current.SetSelectedGameObject(itemUI);
                    Inventory.instance.selectedItemObject = itemUI;
                }
            }
        }
    }
    public void UpdateInventoryUI(){
        foreach(Transform item in itemContent){
            Destroy(item.gameObject);
        }
        Inventory.instance.StartInventoryUI();
    }
    public void GetSelectedItem(){
        if(EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.name != "DialogueButton"){
            var itemUIButton = EventSystem.current.currentSelectedGameObject.GetComponent<InventoryButton>();
            Inventory.instance.selectedItemID = itemUIButton.itemData.id;
        }
    }
}
