using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType { Grass, Dirt, Water }
public class TileStat : MonoBehaviour
{
    public int visited = -1;
    public int xPos = 0;
    public int yPos = 0;

    public Material[] materials = new Material[3];
    public Material currentMaterial;

    [SerializeField]
    
    public TileType currentType;

    // Start is called before the first frame update
    void Start()
    {
        currentType = (TileType)Random.Range(0, 3);

        if (currentType == TileType.Dirt)
        {
            currentMaterial = materials[0];
        }
        if (currentType == TileType.Grass)
        {
            currentMaterial = materials[1];
        }
        if (currentType == TileType.Water)
        {
            currentMaterial = materials[2];
        }

        GetComponent<Renderer>().material = currentMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
