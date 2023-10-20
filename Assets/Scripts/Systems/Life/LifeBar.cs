using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public GameObject character;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {   
        Vector3 newTransform = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z) + offset;
        transform.position = newTransform;
    }
}
