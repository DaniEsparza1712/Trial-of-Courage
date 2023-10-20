using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Grid grid;
    public Transform startPos;
    public Transform targetPos;
    public List<Node> path = new List<Node>();
    private bool lookForPath = false;
    public bool GetLookForPath => lookForPath;
    public void SetLookForPath(bool look){
        lookForPath = look;
    }
    // Start is called before the first frame update
    void Start()
    {
        //FindPath(startPos.position, targetPos.position);
        //StartCoroutine("FindPathCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if(lookForPath){
            FindPath(startPos.position, targetPos.position);
        }
    }

    public void FindPath(Vector3 _startPos, Vector3 _endPos){
        Node startNode = grid.NodeAtPos(_startPos);
        Node targetNode = grid.NodeAtPos(_endPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);

        while(openList.Count > 0){
            Node currentNode = openList[0];
            for(int i = 1; i < openList.Count; i++){
                if(openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost){
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == targetNode){
                GetFinalPath(startNode, currentNode);
            }
            foreach(Node neighbor in grid.GetNeighborNodes(currentNode)){
                if(neighbor.isWall || neighbor.isEmpty || closedList.Contains(neighbor)){
                    continue;
                }
                int moveCost = currentNode.gCost + GetManhattanDistance(currentNode, neighbor);
                if(moveCost < neighbor.gCost || !openList.Contains(neighbor)){
                    neighbor.gCost = moveCost;
                    neighbor.hCost = GetManhattanDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if(!openList.Contains(neighbor)){
                        openList.Add(neighbor);
                    }
                }
            }
        }
        SetLookForPath(false);
    }

    void GetFinalPath(Node _startNode, Node _endNode){
        path.Clear();
        Node currentNode = _endNode;

        while(currentNode != _startNode){
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Add(currentNode);
        path.Reverse();
        grid.finalPath = path;
    }
    int GetManhattanDistance(Node _node1, Node _node2){
        int ix = Mathf.Abs(_node1.gridX - _node2.gridX);
        int iy = Mathf.Abs(_node1.gridY - _node2.gridY);

        return ix + iy;
    }

    IEnumerator FindPathCoroutine(){
        while(true){
            yield return new WaitForSeconds(0.1f);
            if(lookForPath)
                FindPath(startPos.position, targetPos.position);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
            foreach(Node node in path){
                    Gizmos.DrawCube(node.position, Vector3.one * (grid.nodeDiameter - grid.distance));
            }
    }
}
