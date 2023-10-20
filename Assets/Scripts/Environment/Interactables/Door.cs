using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the action of opening a door
[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public string keyID;
    private Animator animator;
    private bool opened;
    public bool IsOpened => opened;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (!opened)
        {
            opened = true;
            animator.SetBool("opened", true);
        }
    }
}
