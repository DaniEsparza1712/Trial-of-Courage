using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
   public Dialogue dialogue;
   public List<DialogueEventHolder> eventHolders = new List<DialogueEventHolder>();
   public UnityEvent endEvent;
   public void TriggerDialogue(){
      FindObjectOfType<DialogueManager>().currentTrigger = this;
      FindObjectOfType<DialogueManager>().ShowDialogue(dialogue, dialogue.charName);
   }

   public int GetDialogueIndex(DialogueSentence dialogueSentence){
      int counter = -1;
      foreach(DialogueEventHolder eventHolder in eventHolders){
         counter++;
         if(eventHolder.triggerSentence == dialogueSentence){
            return counter;
         }
      }
      return -1;
   }
}
