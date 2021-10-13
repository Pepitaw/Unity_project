using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryManager : MonoBehaviour
{
    public static TerritoryManager instance;
    PlayerManager playerManager;
    public List<GameObject> player1Node;
    public List<GameObject> player2Node;
    public GameObject[] allNodes;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TerritoryManager");
        }
        instance = this;
    }
    void Start()
    {
        playerManager = PlayerManager.instance;
        allNodes = new GameObject[transform.childCount];
        for (int i = 0; i < allNodes.Length; i++)
        {
            allNodes[i] = transform.GetChild(i).gameObject;
        }
    }
    void Update()
    {

    }

    public void GetNode(GameObject player, GameObject node)
    {
        if (player == playerManager.player1.gameObject)
        {
            player1Node.Add(node);
            //node.GetComponent<Node>().player=player;
            node.transform.GetChild(0).gameObject.SetActive(true);
            //node.transform.GetChild(0).GetComponent<SpriteRenderer>().color = playerManager.player1.territoryColor;
            return;
        }
        if (player == playerManager.player2.gameObject)
        {
            player2Node.Add(node);
            //node.GetComponent<Node>().player = player;
            node.transform.GetChild(0).gameObject.SetActive(true);
            //node.transform.GetChild(0).GetComponent<SpriteRenderer>().color = playerManager.player2.territoryColor;
            return;
        }
        Debug.Log("some error");
    }
}
