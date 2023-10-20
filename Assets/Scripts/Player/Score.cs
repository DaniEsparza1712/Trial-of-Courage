using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    private TMP_Text display;
    private ItemData itemData;
    GameObject message;
    TMP_Text messageText;
    private int score;
    public int GetCore => score;
    bool rewarded;
    public Score(TMP_Text displayText, int startScore, ItemData rewardItemData, GameObject messageContainer, TMP_Text text){
        display = displayText;
        score = startScore;
        itemData = rewardItemData;
        message = messageContainer;
        messageText = text;
    }
    public void AddScore(int addScore){
        score += addScore;
        Debug.Log(display.text);
        display.text = score.ToString();
        if(score >= 5000 && !rewarded)
            AddItem();
    }

    void AddItem(){
        rewarded = true;
        Inventory.instance.AddToInventory(itemData, 1);
        message.SetActive(true);
        messageText.text = string.Format("You got {0}!", itemData.itemName);
    }
}
