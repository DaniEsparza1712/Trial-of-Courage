using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Transform spawnPos;
    public List<GameObject> projectiles;
    public void Shoot(int index){
        Instantiate(projectiles[index], spawnPos.position, transform.rotation);
    }
}
