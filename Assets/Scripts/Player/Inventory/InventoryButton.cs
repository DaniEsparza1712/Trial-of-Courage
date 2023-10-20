using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public ItemData itemData;
    public Button button;
    private string prevName;
    private string prevDesc;
    private bool selected;
    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate{UseItem(itemData.id);});
    }
    private void Update() {
        if(selected && Input.GetButtonDown("SupportB") && itemData.itemType == ItemData.ItemType.secondaryWeapon){
            PlayerMachine playerMachine = GameObject.Find("Player").GetComponent<PlayerMachine>();
            playerMachine.secWeaponManager.secondaryWeaponDataB = itemData;
            Inventory.instance.secWeaponBSprite.sprite = itemData.icon;
        }
        if(selected && Input.GetButtonDown("SupportA") && itemData.itemType == ItemData.ItemType.secondaryWeapon){
            PlayerMachine playerMachine = GameObject.Find("Player").GetComponent<PlayerMachine>();
            playerMachine.secWeaponManager.secondaryWeaponData = itemData;
            Inventory.instance.secWeaponSprite.sprite = itemData.icon;
        }
    }
    public void UseItem(string key){
        var itemSlot = Inventory.instance.inventorySlots[key];
        EmptyInfo();
        switch (itemSlot.ItemData.itemType){
            case ItemData.ItemType.healthPotion:
                if(itemSlot.HasItem()){
                    Inventory.instance.inventorySlots[key].RemoveItem(1);
                    GameObject.Find("Player").GetComponent<LifeSystem>().AddLife(itemSlot.ItemData.value);
                }
                break;
            case ItemData.ItemType.magicPotion:
                if(itemSlot.HasItem()){
                    Inventory.instance.inventorySlots[key].RemoveItem(1);
                    GameObject.Find("Player").GetComponent<MagicSystem>().AddMagic(itemData.value);
                }

                break;
            case ItemData.ItemType.fullPotion:
                if(itemSlot.HasItem()){
                    Inventory.instance.inventorySlots[key].RemoveItem(1);
                    
                }
                break;
            case ItemData.ItemType.key:
                break;
            case ItemData.ItemType.mainWeapon:
                WeaponManager weaponManager = GameObject.Find("Player").GetComponent<WeaponManager>();
                weaponManager.weapon.damage = itemData.value;
                weaponManager.ChangeActiveWeapon(itemData.itemName);
                Inventory.instance.weaponSprite.sprite = itemData.icon;
                break;
            case ItemData.ItemType.secondaryWeapon:
                PlayerMachine playerMachine = GameObject.Find("Player").GetComponent<PlayerMachine>();
                playerMachine.secWeaponManager.secondaryWeaponData = itemData;
                Inventory.instance.secWeaponSprite.sprite = itemData.icon;
                break;
            case ItemData.ItemType.panacea:
                break;
        }
        Inventory.instance.UpdateInventoryUI();
    }
    public void ChangeInfo(){
        var itemUITitle = Inventory.instance.itemInfo.transform.Find("Title").GetComponent<TMP_Text>();
        var itemUIDesc = Inventory.instance.itemInfo.transform.Find("Description").GetComponent<TMP_Text>();

        prevName = itemUITitle.text;
        prevDesc = itemUIDesc.text;

        itemUITitle.text = itemData.itemName;
        itemUIDesc.text = itemData.description;
    }

    public void EmptyInfo(){
        var itemUITitle = Inventory.instance.itemInfo.transform.Find("Title").GetComponent<TMP_Text>();
        var itemUIDesc = Inventory.instance.itemInfo.transform.Find("Description").GetComponent<TMP_Text>();

        itemUITitle.text = "";
        itemUIDesc.text = "";
    }
    public void ChangeBack(){
        var itemUITitle = Inventory.instance.itemInfo.transform.Find("Title").GetComponent<TMP_Text>();
        var itemUIDesc = Inventory.instance.itemInfo.transform.Find("Description").GetComponent<TMP_Text>();

        itemUITitle.text = prevName;
        itemUIDesc.text = prevDesc;
    }

    public void OnSelect(BaseEventData eventData)
    {
        selected = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        selected = false;
    }
}
