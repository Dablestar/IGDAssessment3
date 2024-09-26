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
        Vector3Int position = new Vector3Int(0, 0, 0);
        foreach (string line in mapInfo)
        {
            foreach (string i in line.Split(","))
            {
                switch (i)
                {
                    case "0":
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
