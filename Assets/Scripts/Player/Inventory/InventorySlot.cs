using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData itemData = new ItemData();
    public int quantity;
    private int quantityLimit;

    public ItemData ItemData => itemData;
    public int Quantity => quantity;
    
    public InventorySlot(ItemData source, int amount){
        itemData = source;
        quantityLimit = amount;
    }
    public InventorySlot(){
        ClearSlot();
    }
    public void ClearSlot(){
        itemData = null;
        quantity = -1;
    }
    public bool AddItem(int amount){
        if(quantity < quantityLimit){
            quantity += amount;
            return true;
        }
        return false;
    }
    public void RemoveItem(int amount){
        quantity -= amount;
    }
    public bool HasItem(){
        if(quantity > 0){
            return true;
        }
        return false;
    }
}
