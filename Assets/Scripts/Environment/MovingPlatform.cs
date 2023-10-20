using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum pos {Left, Center, Right};
    public enum moveDirection{Left, Right};
    public Vector3 moveDistance;
    public float speed;
    public pos startPosOption;
    moveDirection currentDirection;
    Vector3 direction;
    Vector3 startPos;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider triggerCollider = gameObject.AddComponent<BoxCollider>();
        BoxCollider ogCollider = GetComponent<BoxCollider>();
        
        triggerCollider.isTrigger = true;

        float offset = GameObject.Find("Player").GetComponent<CharacterController>().stepOffset * 1.1f;
        Vector3 size = new Vector3(ogCollider.size.x + offset, ogCollider.size.y + offset, ogCollider.size.z + offset);
        triggerCollider.size = size;

        startPos = transform.position;
        switch(startPosOption){
            case pos.Center:
                transform.position = transform.position;
                currentDirection = moveDirection.Right;
                break;
            case pos.Left:
                transform.position -= moveDistance;
                currentDirection = moveDirection.Right;
                break;
            case pos.Right:
                transform.position += moveDistance;
                currentDirection = moveDirection.Left;
                break;
        }
    }

    void FixedUpdate()
    {
        switch(currentDirection){
            case moveDirection.Right:
                distance = Vector3.Distance(startPos + moveDistance, transform.position);

                direction = (startPos + moveDistance);
                if(distance <= 0.1f)
                    currentDirection = moveDirection.Left;
                break;
            case moveDirection.Left:
                distance = Vector3.Distance(startPos - moveDistance, transform.position);

                direction = (startPos - moveDistance); 
                if(distance <= 0.1f)
                    currentDirection = moveDirection.Right;
                break;
        }
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
}
