using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Node;
    [SerializeField]
    private const int mapSize = 5;

    void Start()
    {
        InitializeMap(mapSize);
    }
    void InitializeMap(int size)
    {
        for (int i = -size / 2; i <= size / 2; i++)
        {
            for (int j = -size / 2; j <= size / 2; j++)
            {
                Vector3 pos = new Vector3(i * 2, j * 2, 0);
                Instantiate(Node, pos, Quaternion.identity);
            }
        }
    }
}
