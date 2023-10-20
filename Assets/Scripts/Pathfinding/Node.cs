using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX;
    public int gridY;
    public bool isWall;
    public bool isEmpty;
    public Vector3 position;
    public Node parent;
    public int hCost;
    public int gCost;
    public int fCost => hCost + gCost;

    public Node(bool _isWall, bool _isEmpty, Vector3 _pos, int _x, int _y){
        isWall = _isWall;
        isEmpty = _isEmpty;
        position = _pos;
        gridX = _x;
        gridY = _y;
    }
}
