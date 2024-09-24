using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    private Tilemap map;

    private Tile[] tilePalette;
    // Start is called before the first frame update
    void Start()
    {
        tilePalette = new Tile[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
