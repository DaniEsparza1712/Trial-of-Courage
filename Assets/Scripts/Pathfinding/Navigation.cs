using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public NavMeshAgent agent;
    private void Update() {
        agent.SetDestination(GameObject.Find("Player").transform.position);   
    }
}
