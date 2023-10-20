using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager = new SpawnManager();
    private int bombCounter;
    private int bombLimit = 3;
    public int GetBombCounter => bombCounter;
    public void AddBomb(int quantity){
        spawnManager.bombCounter += quantity;
    }
    private void Start() {
        spawnManager.bombCounter = 0;
    }
    public bool CheckIfCanSpawn(ItemData itemData){
        switch(itemData.itemName){
            case "Bombs":
                if(bombCounter < bombLimit && Inventory.instance.inventorySlots[itemData.id].HasItem())
                    return true;
                else
                    return false;
                break;
        }
        return true;
    }
}
