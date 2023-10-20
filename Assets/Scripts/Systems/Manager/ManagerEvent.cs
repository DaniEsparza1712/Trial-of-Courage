using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerEvent : MonoBehaviour
{
    public UnityEvent unityEvent;
    public void PlayEvent(){
        unityEvent.Invoke();
    }
}
