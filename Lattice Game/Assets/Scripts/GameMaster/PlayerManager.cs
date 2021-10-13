using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    UnitController unitController;
    UIManager uIManager;
    BuildManager buildManager;
    public Player playerScript;
    public Player player1;
    public Player player2;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PlayerManager");
        }
        instance = this;
    }
    void Start()
    {

        uIManager = UIManager.instance;
        buildManager = BuildManager.instance;

        playerScript = player1;
        //playerScript.actionTurn = true;
    }

    public void ChangePlayer()
    {
        //     uIManager.HideUI();
        //     unitController.DisSelectUints();
        //     buildManager.DisSelectCurrentNode();
        //     if (playerScript == player1)
        //     {
        //         playerScript.actionCount = 0;
        //         playerScript.actionTurn = false;
        //         playerScript = player2;
        //         playerScript.actionTurn = true;
        //         return;
        //     }
        //     if (playerScript == player2)
        //     {
        //         playerScript.actionCount = 0;
        //         playerScript.actionTurn = false;
        //         playerScript = player1;
        //         playerScript.actionTurn = true;
        //         return;
        //     }
        //     Debug.Log("Error in ChangePLayer");
    }
}
