using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Text player1Money;
    public Text player2Money;
    public GameObject player1Info;
    public GameObject player2Info;
    GameManager gameManager;

    bool hasBuilded = false;
    bool hasUnits = false;

    void Start()
    {
        gameManager = GameManager.instance;
        player1Info.SetActive(false);
        player2Info.SetActive(false);
    }

    void Update()
    {
        player1Money.text = "$ " + player1.money;
        player2Money.text = "$ " + player2.money;

        //Player1
        if (player1.selectedNode)
        {
            player1Info.SetActive(true);
        }
        else
        {
            player1Info.SetActive(false);
        }

        //Player2
        if (player2.selectedNode)
        {
            player2Info.SetActive(true);
        }
        else
        {
            player2Info.SetActive(false);
        }
    }

    void CheckCondition()
    {
        Player[] target = new Player[2];
        target[0] = player1;
        target[1] = player2;

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].selectedNode.GetComponent<Node>().building)
            {
                hasBuilded = true;
            }
            else
            {
                hasBuilded = false;
            }

            if (target[i].selectedNode.GetComponent<Node>().units[0])
            {
                hasUnits = true;
            }
            else
            {
                hasUnits = false;
            }
        }

    }
}
