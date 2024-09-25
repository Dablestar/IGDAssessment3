using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        Instantiate(player, new Vector3(-8.5f, 3f, 0f), Quaternion.identity, GameObject.Find("Grid").transform);
        enemyList.Add(Instantiate(enemy, new Vector3(8.5f, -3f, 0f), Quaternion.identity, GameObject.Find("Grid").transform));
        enemyList.Add(Instantiate(enemy, new Vector3(8.5f, 3f, 0f), Quaternion.identity, GameObject.Find("Grid").transform));
        enemyList.Add(Instantiate(enemy, new Vector3(-8.5f, -3f, 0f), Quaternion.identity, GameObject.Find("Grid").transform));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}