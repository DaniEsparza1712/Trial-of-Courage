using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Dialogue Choice")]
public class DialogueChoice : ScriptableObject
{
    public string choice;
    public DialogueSentence[] dialogueSentence;
}
