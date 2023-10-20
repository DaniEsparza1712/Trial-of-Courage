using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionBox: MonoBehaviour
{
    public TMP_Text text;
    public DialogueChoice dialogueChoiceData;
    public DialogueManager dialogueManager;
    public DialogueTrigger dialogueTrigger;

    public void InsertDialogue(){
        int counter = 0;
        foreach(DialogueSentence sentence in dialogueChoiceData.dialogueSentence){
            counter++;
            dialogueManager.sentences.Insert(0, sentence);
        }
        dialogueManager.ClearOptions();
        dialogueManager.NextSentece();
    }
}
