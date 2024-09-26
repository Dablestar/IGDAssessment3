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
                Quaternion rotation = Quaternion.identity;
                switch (mapInfo[y][x])
                {
                    case "0":
                        Instantiate(tilePalette[0], position, Quaternion.identity, wallParent.transform);
                        break;
                    case "1":
                        if (y == 0)
                        {
                            //case : y == 0
                            if (x == 0)
                            {
                                //case : origin
                                if (mapInfo[y + 1][x].Equals("2") && mapInfo[y][x + 1].Equals("2"))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 270);
                                }
                            }
                            else if (x == mapInfo[y].Length)
                            {
                                //case : last line 
                                if (mapInfo[y][x - 1].Equals("2") && mapInfo[y + 1][x].Equals("2"))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 180);
                                }
                            }
                        }
                        else if (y == mapInfo.Count)
                        {
                            //case : y == last line
                            if (x == 0)
                            {
                                //case : origin
                                if (mapInfo[y - 1][x].Equals("2") && mapInfo[y][x + 1].Equals("2"))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 90);
                                }
                            }
                            else if (x == mapInfo[y].Length)
                            {
                                //case : last line 
                                if (mapInfo[y][x - 1].Equals("2") && mapInfo[y - 1][x].Equals("2"))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 180);
                                }
                            }
                        }
                        else
                        {
                            if (x == 0)
                            {
                                if ((mapInfo[y - 1][x].Equals("2") || mapInfo[y - 1][x].Equals("3")) &&
                                    (mapInfo[y][x + 1].Equals("2") || mapInfo[y][x + 1].Equals("3")))
                                {
                                    rotation = Quaternion.identity;
                                }

                                if ((mapInfo[y + 1][x].Equals("2") || mapInfo[y + 1][x].Equals("3")) &&
                                    (mapInfo[y][x + 1].Equals("2") || mapInfo[y][x + 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 90);
                                }
                            }
                            else if (x == mapInfo[y].Length)
                            {
                                //case : last line 
                                if ((mapInfo[y - 1][x].Equals("2") || mapInfo[y - 1][x].Equals("3")) &&
                                    (mapInfo[y][x - 1].Equals("2") || mapInfo[y][x - 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 270);
                                }

                                if ((mapInfo[y + 1][x].Equals("2") || mapInfo[y + 1][x].Equals("3")) &&
                                    (mapInfo[y][x - 1].Equals("2") || mapInfo[y][x - 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 180);
                                }
                            }
                            else
                            {
                                if ((mapInfo[y - 1][x].Equals("2") || mapInfo[y - 1][x].Equals("3")) &&
                                    (mapInfo[y][x + 1].Equals("2") || mapInfo[y][x + 1].Equals("3")))
                                {
                                    rotation = Quaternion.identity;
                                }

                                if ((mapInfo[y - 1][x].Equals("2") || mapInfo[y - 1][x].Equals("3")) &&
                                    (mapInfo[y][x - 1].Equals("2") || mapInfo[y][x - 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 270);
                                }

                                if ((mapInfo[y + 1][x].Equals("2") || mapInfo[y + 1][x].Equals("3")) &&
                                    (mapInfo[y][x + 1].Equals("2") || mapInfo[y][x + 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 90);
                                }

                                if ((mapInfo[y + 1][x].Equals("2") || mapInfo[y + 1][x].Equals("3")) &&
                                    (mapInfo[y][x - 1].Equals("2") || mapInfo[y][x - 1].Equals("3")))
                                {
                                    rotation *= Quaternion.Euler(0, 0, 180);
                                }
                            }
                        }

                        Instantiate(tilePalette[1], position, rotation, wallParent.transform);
                        break;
                    case "2":
                        //Base case : border
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