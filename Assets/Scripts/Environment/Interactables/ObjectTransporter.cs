using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransporter : Interactable
{
    public GameObject transportee;
    public List<Transform> positions = new();
    private int currentPos;
    void MoveToNextPos()
    {
        currentPos = Mathf.Clamp(currentPos++, 0, positions.Count - 1);
    }
    void Transport()
    {
        transportee.transform.position = positions[currentPos].transform.position;
    }
    public override void Action()
    {
        Transport();
        MoveToNextPos();
    }
}
