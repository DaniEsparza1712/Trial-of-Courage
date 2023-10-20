using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Pathfinding pathfinding;
    public float speed;
    Vector3 movePos;
    // Start is called before the first frame update
    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pathfinding.path.Count > 0){
            movePos = new Vector3(pathfinding.path[0].position.x, transform.position.y, pathfinding.path[0].position.z);
            transform.position =  Vector3.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, movePos) == 0.0f){
                pathfinding.path.Remove(pathfinding.path[0]);
            }
        }
    }
}
