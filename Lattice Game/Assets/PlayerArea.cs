using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    GameManager gameManager;
    public GameObject player;
    public List<GameObject> allNodes;
    public List<GameObject> playersNodes;
    public List<GameObject> surroundNodes;
    public Color surroundNodesColor;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    public void init()
    {
        allNodes = gameManager.allNode;
    }
    void Update()
    {
        foreach (var node in allNodes)
        {
            Node n = node.GetComponent<Node>();
            if (n.owner == player)
            {
                if (!playersNodes.Contains(node))
                {
                    playersNodes.Add(node);
                    surroundNodes.Add(node);
                }
            }
            else if (n.owner != null)
            {
                if (playersNodes.Contains(node))
                {
                    playersNodes.Remove(node);
                    surroundNodes.Remove(node);
                }
            }
        }

        foreach (var node in playersNodes)
        {
            Node n = node.GetComponent<Node>();
            n.ShowMark(player.GetComponent<Player>(), true);

            for (int i = 0; i < n.aroundNode.Length; i++)
            {
                GameObject aroundN = n.aroundNode[i];
                if (aroundN)
                {
                    if (!surroundNodes.Contains(aroundN))
                    {
                        surroundNodes.Add(aroundN);
                    }
                }
            }
        }
    }

    public void ShowSurroundNodes()
    {
        foreach (var node in surroundNodes)
        {
            node.GetComponent<SpriteRenderer>().color = surroundNodesColor;
        }
    }

    public void HideSurroundNodes()
    {
        foreach (var node in surroundNodes)
        {
            node.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
