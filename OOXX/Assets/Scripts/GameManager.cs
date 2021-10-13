using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int winner;
    [SerializeField]
    private int size = 3;
    public GameObject node;
    public int currentTurn;
    [SerializeField]
    private List<Node> nodes;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("more than one GameManager");
        }
    }
    void Start()
    {
        nodes = new List<Node>();
        InstanceGrid();
        currentTurn = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void InstanceGrid()
    {
        float offset = 1.2f;
        for (int i = -size / 2; i <= size / 2; i++)
        {
            for (int j = -size / 2; j <= size / 2; j++)
            {
                Vector3 pos = new Vector3(i * offset, j * offset);
                GameObject n = Instantiate(node, pos, Quaternion.identity);
                nodes.Add(n.GetComponent<Node>());
            }
        }
    }

    void RestartGame()
    {
        foreach (var n in nodes)
        {
            Destroy(n.gameObject);
        }
        nodes.Clear();
        InstanceGrid();
        currentTurn = 0;
    }

    void CheckWinCondition()
    {
        for (int i = 0; i < 3; i++)
        {
            //三直
            if (nodes[i].state == nodes[1 + i].state && nodes[0 + i].state == nodes[2 + i].state)
            {
                ;
                if (nodes[i].state == 1)
                {
                    Debug.Log("O win");
                    winner = 0;
                    EndGame();
                }
                if (nodes[i].state == 2)
                {
                    Debug.Log("X win");
                    winner = 1;
                    EndGame();
                }
            }
            //三橫
            if (nodes[i].state == nodes[i + 3].state && nodes[i].state == nodes[i + 6].state)
            {
                if (nodes[i].state == 1)
                {
                    Debug.Log("O win");
                    winner = 0;
                    EndGame();
                }
                if (nodes[i].state == 2)
                {
                    Debug.Log("X win");
                    winner = 1;
                    EndGame();
                }
            }
        }
        //兩斜
        if (nodes[0].state == nodes[4].state && nodes[0].state == nodes[8].state)
        {
            if (nodes[0].state == 1)
            {
                Debug.Log("O win");
                winner = 0;
                EndGame();
            }
            if (nodes[0].state == 2)
            {
                Debug.Log("X win");
                winner = 1;
                EndGame();
            }
        }
        if (nodes[2].state == nodes[4].state && nodes[2].state == nodes[6].state)
        {
            if (nodes[2].state == 1)
            {
                Debug.Log("O win");
                winner = 0;
                EndGame();
            }
            if (nodes[2].state == 2)
            {
                Debug.Log("X win");
                winner = 1;
                EndGame();
            }
        }
    }

    public void ChanageTurn()
    {
        if (currentTurn == 0)
        {
            currentTurn = 1;
        }
        else
        {
            currentTurn = 0;
        }
        CheckWinCondition();
    }

    void EndGame()
    {
        foreach (var n in nodes)
        {
            n.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
