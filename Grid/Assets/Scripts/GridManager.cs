using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridManager : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;

    public GameObject tilePrefab;
    public GameObject lionPrefab;
    public GameObject chickenPrefab;

    public Vector3 bottomLeftCoords = new Vector3(0, 0, 0);

    [SerializeField]
    public GameObject[,] gridArray;
    
    //current node game object

    
    void Awake()
    {
        gridArray = new GameObject[columns, rows];

        if (tilePrefab)
        {
            GenerateGrid();
        }
        else print("Missing TilePrefab");
    }

    // Start is called before the first frame update
    void Start()
    {
        int randNum = Random.Range(0, 9);
        int RandNum2 = Random.Range(0, 9);
        //GameObject lion = Instantiate(lionPrefab, new Vector3 (bottomLeftCoords.x + scale * randNum, bottomLeftCoords.y, bottomLeftCoords.z + scale * RandNum2), Quaternion.identity);
        GameObject chicken = Instantiate(chickenPrefab, new Vector3(bottomLeftCoords.x + scale * RandNum2, bottomLeftCoords.y, bottomLeftCoords.z + scale * randNum), Quaternion.identity);

        //lion.GetComponent<LionManager>().xPos = (int)(bottomLeftCoords.x + scale * randNum);
        //lion.GetComponent<LionManager>().yPos = (int)(bottomLeftCoords.z + scale * RandNum2);
        chicken.GetComponent<ChickenManager>().xPos = (int)(bottomLeftCoords.x + scale * RandNum2);
        chicken.GetComponent<ChickenManager>().yPos = (int)(bottomLeftCoords.z + scale * randNum);


        /*
         * set start node to 0
         * set non start nodes to infinity
         * 
         */


    }

    // Update is called once per frame
    void Update()
    {

    }


    void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(tilePrefab, new Vector3(bottomLeftCoords.x + scale * i, bottomLeftCoords.y, bottomLeftCoords.z + scale + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<TileStat>().xPos = i;
                obj.GetComponent<TileStat>().yPos = j;
   

                gridArray[i, j] = obj;
            }
        }
    }

    /*
     * look at current x,y and add +1 to get all adjacent 8 nodes
     * don't backtrack, only look at nodes that haven't been considered
     * 
     * 
     */


    /*
     * While(gridArray.length > 0)
     * set current node (lowest cost)
     * remove current node from gridArray
     * 
     * foreach(node adjacent to current node)
     * if current node.cost + cost to adjacentnode < adjacentNode.cost 
     * adjacentNode.cost = curNode.cost +cost to adjacentnode
     * 
     * when done, go back to start node and walk
     * path with smallest cost
     */
}
