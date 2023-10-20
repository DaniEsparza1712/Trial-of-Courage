using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public int amount;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            if(Inventory.instance.AddToInventory(itemData, amount)){
                Destroy(gameObject);
            }
        }
    }
}
