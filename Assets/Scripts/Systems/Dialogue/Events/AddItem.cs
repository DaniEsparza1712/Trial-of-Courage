using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddItem : MonoBehaviour
{
    public ItemData itemData;
    public int quantity;
    public bool giveItem;
    public void Add(){
        if(giveItem){
            Inventory.instance.AddToInventory(itemData, quantity);
            Inventory.instance.SetMessage(itemData);
        }
    }
    public void SetGiveItem(bool give){
        giveItem = give;
    }
}
