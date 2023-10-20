using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDetector : MonoBehaviour
{
    public Collider[] talkablesCollider;
    public PlayerMachine playerMachine;
    public LayerMask talkableMask;
    public Image specialActionImage;
    public Sprite sprintSprite;
    public Sprite talkSprite;
    public Sprite chestSprite;
    public Sprite kissSprite;
    public Sprite doorSprite;
    public Sprite lockedSprite;
    public string action;

    // Update is called once per frame
    void Update()
    {
        talkablesCollider = Physics.OverlapSphere(transform.position, 2, talkableMask);
        if(talkablesCollider.Length > 0 && talkablesCollider[0].CompareTag("Talkable")){
            action = "Talk";
            specialActionImage.sprite = talkSprite;
        }
        else if(talkablesCollider.Length > 0 && talkablesCollider[0].CompareTag("Chest")){
            action = "Chest";
            specialActionImage.sprite = chestSprite;
        }
        else if(talkablesCollider.Length > 0 && talkablesCollider[0].CompareTag("Kissable")){
            action = "Kiss";
            specialActionImage.sprite = kissSprite;
        }
        else if(talkablesCollider.Length > 0 && talkablesCollider[0].CompareTag("Door")){
            action = "Door";
            specialActionImage.sprite = doorSprite;
        }
        else if (talkablesCollider.Length > 0 && talkablesCollider[0].CompareTag("LockedDoor"))
        {
            if (!talkablesCollider[0].GetComponent<Door>().IsOpened)
            {
                action = "LockedDoor";
                specialActionImage.sprite = lockedSprite;
            }
        }
        else
        {
            action = "";
            specialActionImage.sprite = sprintSprite;
        }
    }
}
