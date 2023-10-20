using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEvents : MonoBehaviour
{
    public void Clear(){
        gameObject.GetComponent<DialogueTrigger>().endEvent.RemoveAllListeners();
    }
}
