using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    TerritoryManager territoryManager;
    public GameObject nodePrefab;
    public List<GameObject> allNode;
    public GameObject mainCamera;


    [Header("Playing Settings")]
    public int mapSize;
    public Player player1;
    public Player player2;
    //public GameObject[] StartPlayer1Territory;
    //public GameObject[] StartPlayer2Territory;

    //[Header("Untiy Settings")

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameManager");
            return;
        }
        instance = this;
    }

    void Start()
    {
        territoryManager = TerritoryManager.instance;
        InstantiateNode(mapSize);
        mainCamera.transform.position = new Vector3((mapSize - 1) * 2, (mapSize - 1) * 2, -10);
        player1.init();
        player2.init();
        StartCoroutine(GetMoney());
        // InitTerritory();
    }

    void InstantiateNode(int size)
    {
        //Debug.Log("instantiateNode");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 position = new Vector3(4 * i, 4 * j, 0);
                GameObject n = Instantiate(nodePrefab, position, Quaternion.identity);
                allNode.Add(n);
                //Debug.Log("add node to allNode");
            }
        }
        for (int i = 0; i < allNode.Count; i++)
        {
            GameObject right, up, left, down;

            right = (i + 5 < allNode.Count ? allNode[i + 5] : null);
            up = (i + 1 < allNode.Count ? allNode[i + 1] : null);
            if ((i + 1) % 5 == 0)
            {
                up = null;
            }
            left = (i - 5 >= 0 ? allNode[i - 5] : null);
            down = (i - 1 >= 0 ? allNode[i - 1] : null);
            if ((i - 1) % 5 == 4)
            {
                down = null;
            }
            allNode[i].GetComponent<Node>().GetAroundNode(right, up, left, down);
        }
    }


    // void InitTerritory()
    // {
    //     for (int i = 0; i < StartPlayer1Territory.Length; i++)
    //     {
    //         territoryManager.GetNode(playerManager.player1.gameObject, StartPlayer1Territory[i]);
    //     }

    //     for (int i = 0; i < StartPlayer2Territory.Length; i++)
    //     {
    //         territoryManager.GetNode(playerManager.player2.gameObject, StartPlayer2Territory[i]);
    //     }
    // }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     playerManager.ChangePlayer();
        // }

        // if (Input.GetKeyDown(KeyCode.N))
        // {
        //     NextTurn();
        // }

        // if (playerManager.playerScript.actionCount >= 10)
        // {
        //     Debug.Log("you can not move anymore, have to start next turn");
        //     NextTurn();
        // }
    }

    IEnumerator GetMoney()
    {
        int i = 0;
        while (i == 0)
        {
            yield return new WaitForSeconds(5);
            player1.money += 1;
            player2.money += 1;
        }
    }
}
