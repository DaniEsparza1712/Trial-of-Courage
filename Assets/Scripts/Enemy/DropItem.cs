using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public List<GameObject> droppables = new List<GameObject>();
    public void Drop(){
        int index = Random.Range(0, droppables.Count + 3);
        if(index < droppables.Count)
            Instantiate(droppables[index], transform.position, droppables[index].transform.rotation);
    }
}
