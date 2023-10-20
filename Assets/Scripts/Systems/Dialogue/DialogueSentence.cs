using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue System/Dialogue Sentence")]
public class DialogueSentence: ScriptableObject
{
    [TextArea(3, 10)]
    public string sentence;
    public DialogueChoice[] choices;
    
}
