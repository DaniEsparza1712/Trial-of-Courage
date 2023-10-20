using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    public bool opened;
    public Animator animator;
    public ItemData itemData;
    public int quantity;
    Vector3 startRotation;

    public void ChestEvent(){
        if(!opened){
            StartCoroutine("RotateTop");
        }
    }

    IEnumerator RotateTop(){
        opened = true;
        this.gameObject.tag = "Untagged";
        this.gameObject.layer = LayerMask.NameToLayer("Wall");
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1);
        AddItem();
    }
    void AddItem(){
        Inventory.instance.AddToInventory(itemData, quantity);
        Inventory.instance.SetMessage(itemData);
    }
}
