using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 1)]
    public int playerIndex;
    public Color playerColor;
    public int money;

    [HideInInspector]
    public GameObject startNode;
    [HideInInspector]
    public GameObject hoverNode;
    [HideInInspector]
    public GameObject selectedNode;
    public NodeInfo nodeInfo;
    Rigidbody2D rb2d;

    [Header("Prefabs")]
    public GameObject basePrefab;

    [HideInInspector]
    GameManager gameManager;
    BuildManager buildManager;
    UnitController unitController;
    PlayerArea playerArea;


    void Start()
    {
        gameManager = GameManager.instance;
        buildManager = BuildManager.instance;
        unitController = GetComponent<UnitController>();
        rb2d = GetComponent<Rigidbody2D>();
        playerArea = GetComponent<PlayerArea>();
    }

    void Update()
    {
        if (playerIndex == 0)
        {
            ControllMode0();
        }
        if (playerIndex == 1)
        {
            ControllMode1();
        }
    }

    public void init()
    {
        if (playerIndex == 0)
        {
            startNode = gameManager.allNode[0];
        }
        if (playerIndex == 1)
        {
            startNode = gameManager.allNode[24];
        }
        startNode.GetComponent<Node>().owner = gameObject;
        GetComponent<PlayerArea>().init();
        hoverNode = startNode;
        transform.position = startNode.transform.position;
    }

    public void ControllMode0()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveToNextNode(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToNextNode(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToNextNode(3);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToNextNode(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectNode();
        }

        if (selectedNode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Build();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ProductUnit();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                MoveUnit();
            }
        }
    }

    public void ControllMode1()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToNextNode(0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToNextNode(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToNextNode(2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToNextNode(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SelectNode();
        }

        if (selectedNode)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Build();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                ProductUnit();
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                MoveUnit();
            }
        }
    }

    public void MoveToNextNode(int dir)
    {
        for (int i = 0; i < 4; i++)
        {
            if (dir == i)
            {
                GameObject nextNode = hoverNode.GetComponent<Node>().aroundNode[i];
                if (nextNode != null)
                {
                    //StartCoroutine(MovePlayer(nextNode.transform));
                    MovePlayer(nextNode.transform);
                    hoverNode = nextNode;
                }
            }
        }
    }
    void MovePlayer(Transform target)
    {
        transform.position = target.position;
    }
    // IEnumerator MovePlayer(Transform target)
    // {
    //     Vector3 dir = target.position - transform.position;

    //     while (Vector3.Distance(target.position, transform.position) > 0.05f)
    //     {
    //         transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);
    //         yield return new WaitForSeconds(Time.deltaTime);
    //     }
    // }

    void SelectNode()
    {
        if (selectedNode == hoverNode)
        {
            selectedNode.GetComponent<Node>().DisSelected(this);
            selectedNode = null;
            nodeInfo.HideInfo();
            return;
        }
        if (selectedNode)
        {
            selectedNode.GetComponent<Node>().DisSelected(this);
            selectedNode = null;
            nodeInfo.HideInfo();
        }


        nodeInfo.ShowInfo();
        selectedNode = hoverNode;
        selectedNode.GetComponent<Node>().BeSelected(this);
        if (selectedNode.GetComponent<Node>().units.Count > 0)
        {
            unitController.SelectUnits(selectedNode.GetComponent<Node>().units);
        }
    }

    void Build()
    {
        Node node = selectedNode.GetComponent<Node>();
        if (node.building)
        {
            return;
        }

        if (basePrefab.GetComponent<Building>().cost > money)
        {
            return;
        }

        if (!playerArea.playersNodes.Contains(node.gameObject))
        {
            return;
        }
        money -= basePrefab.GetComponent<Building>().cost;
        node.Build(basePrefab);
    }

    void ProductUnit()
    {
        Node node = selectedNode.GetComponent<Node>();
        if (node.building == null)
        {
            return;
        }
        Base b = node.building.GetComponent<Base>();
        b.ProductWorker();
    }

    void MoveUnit()
    {
        if (!playerArea.surroundNodes.Contains(hoverNode))
        {
            Debug.Log("unit can not move to here");
            return;
        }
        Node node = selectedNode.GetComponent<Node>();
        unitController.SelectUnits(node.units);
        unitController.MoveUnitsToNode(hoverNode);
    }
}
