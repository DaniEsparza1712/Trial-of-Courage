using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnAwake : MonoBehaviour
{
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }
}
