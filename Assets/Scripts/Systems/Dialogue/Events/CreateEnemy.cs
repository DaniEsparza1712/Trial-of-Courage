using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public void Create(){
        Instantiate(enemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
