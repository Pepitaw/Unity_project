using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
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
    //public NodeInfo nodeInfo;
    Rigidbody2D rb2d;

    [Header("Prefabs")]
    public GameObject basePrefab;

    [HideInInspector]
    GameManager gameManager;
    //BuildManager buildManager;
    //UnitController unitController;
    //PlayerArea playerArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
