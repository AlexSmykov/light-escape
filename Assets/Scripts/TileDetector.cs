using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDetector : MonoBehaviour
{
    public Tilemap tilemap;
    public float grassSpeedMul;
    public float dirtSpeedMul;
    public float waterSpeedMul;
    public float roadSpeedMul;
    public float swampSpeedMul;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mul = 1.0f;
        var tile = tilemap.GetTile(Vector3Int.RoundToInt(transform.position));
        if (tile != null)
        {
            string tileName = tilemap.GetTile(Vector3Int.RoundToInt(transform.position)).name;
            if (tileName.StartsWith("Dirt"))
            {
                mul = dirtSpeedMul;
            }
            else if (tileName.StartsWith("Grass"))
            {
                mul = grassSpeedMul;
            }
            else if (tileName.StartsWith("Road"))
            {
                mul = roadSpeedMul;
            }
            else if (tileName.StartsWith("Swamp"))
            {
                mul = swampSpeedMul;
            }
            else if (tileName.StartsWith("Water"))
            {
                mul = waterSpeedMul;
            }
            GetComponent<PlayerController>().playerTerrainSpeed = mul;
        }
    }
}
