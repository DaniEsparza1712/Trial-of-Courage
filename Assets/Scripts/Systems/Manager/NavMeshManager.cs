using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class NavMeshManager : MonoBehaviour
{
    public NavMeshSurface meshSurface;
    private void Update() {
        meshSurface.BuildNavMesh();
    }
}
