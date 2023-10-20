using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPos;
    public LayerMask wallMask;
    public Vector2 gridSize;
    public float nodeRadius;
    public float nodeDiameter => nodeRadius * 2;
    public float distance;
    public Transform playerTransform;
    Node[,] grid;
    int gridSizeX, gridSizeY;
    public List<Node> finalPath;
    private void Start() {
        gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);

        CreateGrid();
    }
    private void Update() {
        Vector3 posToMove = playerTransform.position;
        posToMove.y = 0;
        transform.position = posToMove;
        
        CreateGrid();
    }
    void CreateGrid(){
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position + Vector3.left * gridSize.x / 2  - Vector3.forward * gridSize.y / 2;

        for(int y = 0; y < gridSizeY; y++){
            for(int x = 0; x < gridSizeX; x++){
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool isWall = false;
                if(Physics.CheckSphere(worldPoint, nodeRadius, wallMask)){
                    isWall = true;
                }
                if(!Physics.CheckSphere(worldPoint, nodeRadius)){
                    grid[x, y] = new Node(isWall, true, worldPoint, x, y);
                }
                else{
                    grid[x, y] = new Node(isWall, false, worldPoint, x, y);
                }
            }
        }
    }
    public Node NodeAtPos(Vector3 worldPos){
        float gridOriginX = transform.position.x - gridSizeX/2;
        float gridOriginY = transform.position.z - gridSizeY/2;

        float x = worldPos.x - gridOriginX;
        float y = worldPos.z - gridOriginY;
        
        float xNodes = x / nodeDiameter;
        float yNodes = y / nodeDiameter;

        int xNode = Mathf.RoundToInt(xNodes);
        int yNode = Mathf.RoundToInt(yNodes);

        Debug.Log(xNode + ", " + yNode);

        return grid[xNode, yNode];
    }
    public List<Node> GetNeighborNodes(Node _node){
        List<Node> neighborNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //Right check
        xCheck = _node.gridX + 1;
        yCheck = _node.gridY;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Left check
        xCheck = _node.gridX -1;
        yCheck = _node.gridY;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Up check
        xCheck = _node.gridX;
        yCheck = _node.gridY + 1;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Down check
        xCheck = _node.gridX;
        yCheck = _node.gridY - 1;
        if(xCheck >= 0 && xCheck < gridSizeX){
            if(yCheck >= 0 && yCheck < gridSizeY){
                neighborNodes.Add(grid[xCheck, yCheck]);
            }
        }

        return neighborNodes;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, 1, gridSize.y));
        if(grid != null){
            foreach(Node node in grid){
                if(node.isWall){
                    Gizmos.color = Color.yellow;
                }
                else if(node.isEmpty){
                    Gizmos.color = Color.black;
                }
                else{
                    Gizmos.color = Color.clear;
                }
                Gizmos.DrawCube(node.position, Vector3.one * (nodeDiameter - distance));
            }
        }
    }

}
