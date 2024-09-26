using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class LevelGenerator : MonoBehaviour
{
    private const string path = "Assets/PacManLevelMap.csv";
    [SerializeField] private GameObject[] tilePalette;
    private List<string> mapInfo;
    private Vector3 generatorCoordinate;

    private GameObject parent;
    private Tilemap wallParent;
    private Tilemap palletParent;
    
    // Start is called before the first frame update
    void Start()
    {
        mapInfo = new List<string>();
        GetMapInfoFromFile();
        parent = GameObject.Find("Grid");
        wallParent = Instantiate(new GameObject("Walls"), parent.transform).AddComponent<Tilemap>();
        palletParent = Instantiate(new GameObject("Pallets"), parent.transform).AddComponent<Tilemap>();

        wallParent.transform.position = new Vector3(40f, 0f, 0f);
        palletParent.transform.position = new Vector3(40f, 0f, 0f);
        CreateMap();
    }
    
    public void GetMapInfoFromFile()
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        TextReader reader = new StreamReader(fileStream);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            mapInfo.Add(line);
        }
        reader.Close();
    }

    public void CreateMap()
    {
        Vector3Int position = Vector3Int.FloorToInt(wallParent.transform.position);
        int origin = position.x;
        for (int y=0; y<mapInfo.Count; y++)
        {
            bool xStarted = false;
            bool yStarted = false;
            string[] line = mapInfo[y].Split(",");
            Debug.Log(line.ToString());
            for (int x=0; x<line.Length; x++)
            {
                Quaternion rotation = Quaternion.identity;
                switch (line[x])
                {
                    case "0":
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        break;
                    case "1":
                        if (yStarted)
                        {
                            if (xStarted)
                            {
                                
                            }
                        }
                        else
                        {
                            if (xStarted)
                            {
                                
                            }
                        }
                        Instantiate(tilePalette[1], position, rotation, wallParent.transform);
                        break;
                    case "2":
                        if ((y == 0 || y == mapInfo.Count))
                        {
                            rotation *= Quaternion.Euler(0, 0, 90f);
                        }
                        Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                        break;
                    case "3":
                        Instantiate(tilePalette[3], position, Quaternion.identity, wallParent.transform);
                        break;
                    case "4":
                        Instantiate(tilePalette[4], position, Quaternion.identity, wallParent.transform);
                        break;
                    case "5":
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        Instantiate(tilePalette[5], position, Quaternion.identity, palletParent.transform);
                        break;
                    case "6":
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        Instantiate(tilePalette[6], position, Quaternion.identity, palletParent.transform);
                        break;
                    case "7":
                        Instantiate(tilePalette[7], position, Quaternion.identity, wallParent.transform);
                        break;
                    default:
                        break;
                }
                position += Vector3Int.right;
            }

            position.x = origin;
            position += Vector3Int.down;
        }
    }
}
