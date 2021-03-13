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
        GameObject lion = Instantiate(lionPrefab, new Vector3 (bottomLeftCoords.x + scale * randNum, bottomLeftCoords.y, bottomLeftCoords.z + scale * RandNum2), Quaternion.identity);
        GameObject chicken = Instantiate(chickenPrefab, new Vector3(bottomLeftCoords.x + scale * RandNum2, bottomLeftCoords.y, bottomLeftCoords.z + scale * randNum), Quaternion.identity);

        lion.GetComponent<LionManager>().xPos = (int)(bottomLeftCoords.x + scale * randNum);
        lion.GetComponent<LionManager>().yPos = (int)(bottomLeftCoords.z + scale * RandNum2);
        chicken.GetComponent<ChickenManager>().xPos = (int)(bottomLeftCoords.x + scale * RandNum2);
        chicken.GetComponent<ChickenManager>().yPos = (int)(bottomLeftCoords.z + scale * randNum);


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


}
