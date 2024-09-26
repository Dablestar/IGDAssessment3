using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    private const string path = "Assets/PacManLevelMap.csv";
    [SerializeField] private GameObject[] tilePalette;
    private List<string[]> mapInfo;
    private Vector3 generatorCoordinate;

    private GameObject parent;
    private Tilemap wallParent;
    private Tilemap palletParent;

    // Start is called before the first frame update
    void Start()
    {
        mapInfo = new List<string[]>();
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
            mapInfo.Add(line.Split(","));
        }

        reader.Close();
    }


    public void CreateMap()
    {
        Vector3Int position = Vector3Int.FloorToInt(wallParent.transform.position);
        int origin = position.x;
        for (int y = 0; y < mapInfo.Count; y++)
        {
            for (int x = 0; x < mapInfo[y].Length; x++)
            {
                string upNeighbor = y > 0 ? mapInfo[y - 1][x] : "0";
                string downNeighbor = y < mapInfo.Count - 1 ? mapInfo[y + 1][x] : "0";
                string leftNeighbor = x > 0 ? mapInfo[y][x - 1] : "0";
                string rightNeighbor = x < mapInfo[y].Length - 1 ? mapInfo[y][x + 1] : "0";

                Quaternion rotation = Quaternion.identity;
                switch (mapInfo[y][x])
                {
                    case "0":
                        Debug.Log($"x : {x}, y: {y}");
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        break;
                   
                    case "2":
                        Debug.Log($"x : {x}, y: {y}");
                        //Base case : border
                        if ((y == 0 || y == mapInfo.Count))
                        {
                            rotation *= Quaternion.Euler(0, 0, 90f);
                            Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                            break;
                        }

                        if (x == 0)
                        {
                            if (mapInfo[y][x + 1].Equals("2"))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                                break;
                            }
                        }
                        else if (x == mapInfo[y].Length - 1)
                        {
                            if (mapInfo[y][x - 1].Equals("2"))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                                break;
                            }
                        }

                        if (x != 0 && x != mapInfo[y].Length - 1)
                        {
                            if ((mapInfo[y][x - 1].Equals("3") || mapInfo[y][x - 1].Equals("2")) ||
                                (mapInfo[y][x + 1].Equals("3") || mapInfo[y][x + 1].Equals("2")))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                                break;
                            }
                        }

                        
                        Instantiate(tilePalette[2], position, rotation, wallParent.transform);
                        break;
                    case "1":
                    case "3":
                        if (rightNeighbor.Equals("2") || rightNeighbor.Equals("4"))
                        {
                            if ((downNeighbor.Equals("2") || downNeighbor.Equals("4")))
                                rotation *= Quaternion.Euler(0, 0, 0);
                            else if (upNeighbor.Equals("4")|| upNeighbor.Equals("4"))
                                rotation *= Quaternion.Euler(0, 0, 270);
                        }
                        else if ((leftNeighbor.Equals("2") || leftNeighbor.Equals("4")))
                        {
                            if (downNeighbor.Equals("2")  || downNeighbor.Equals("4"))
                                rotation *= Quaternion.Euler(0, 0, 90);
                            else if (upNeighbor.Equals("2") || upNeighbor.Equals("4"))
                                rotation *= Quaternion.Euler(0, 0, 180);
                        }
                        Instantiate(tilePalette[1], position, rotation, wallParent.transform);
                        break;
                        
                    case "4":
                        Debug.Log($"x : {x}, y: {y}");
                        //Base case : border
                        if ((y == 0 || y == mapInfo.Count))
                        {
                            rotation *= Quaternion.Euler(0, 0, 90f);
                            Instantiate(tilePalette[4], position, rotation, wallParent.transform);
                            break;
                        }

                        if (x == 0)
                        {
                            if (mapInfo[y][x + 1].Equals("2"))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[4], position, rotation, wallParent.transform);
                                break;
                            }
                        }

                        if (x == mapInfo[y].Length - 1)
                        {
                            if (mapInfo[y][x - 1].Equals("2"))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[4], position, rotation, wallParent.transform);
                                break;
                            }
                        }
                        else
                        {
                            if ((mapInfo[y][x - 1].Equals("3") || mapInfo[y][x - 1].Equals("2")) ||
                                (mapInfo[y][x + 1].Equals("3") || mapInfo[y][x + 1].Equals("2")))
                            {
                                rotation *= Quaternion.Euler(0, 0, 90f);
                                Instantiate(tilePalette[4], position, rotation, wallParent.transform);
                                break;
                            }
                        }

                        Instantiate(tilePalette[4], position, Quaternion.identity, wallParent.transform);
                        break;
                    case "5":
                        Debug.Log($"x : {x}, y: {y}");
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        Instantiate(tilePalette[5], position, Quaternion.identity, palletParent.transform);
                        break;
                    case "6":
                        Debug.Log($"x : {x}, y: {y}");
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        Instantiate(tilePalette[6], position, Quaternion.identity, palletParent.transform);
                        break;
                    case "7":
                        Debug.Log($"x : {x}, y: {y}");
                        if ((y == 0 || y == mapInfo.Count))
                        {
                            rotation *= Quaternion.Euler(0, 0, -90f);
                        }
                        else
                        {
                            if (x != 0 && x != mapInfo[y].Length - 1)
                            {
                                if ((mapInfo[y - 1][x].Equals("0") || mapInfo[y][x - 1].Equals("2")) ||
                                    (mapInfo[y + 1][x].Equals("0") || mapInfo[y][x + 1].Equals("2")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, -90f);
                                }
                            }
                        }

                        Instantiate(tilePalette[7], position, rotation, wallParent.transform);
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