using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    public List<DialogueSentence> newDialogues;

    public void ReplaceDialogues(){
        List<DialogueSentence> oldDialogues = gameObject.GetComponent<DialogueTrigger>().dialogue.dialogues;
        oldDialogues.Clear();
        foreach(DialogueSentence sentence in newDialogues){
            oldDialogues.Add(sentence);
        }
    }
}
