using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject target;
    public GameObject buildUI;
    GameObject currentNode;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one buildManager");
        }
        instance = this;
    }

    void Start()
    {
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
    }


    public void SelectNodeToBuild(GameObject _node)
    {
        if (currentNode == _node)
        {
            DisSelectCurrentNode();
            return;
        }

        if (currentNode != null)
        {
            DisSelectCurrentNode();
            //return;
        }

        currentNode = _node;

        //currentNode.GetComponent<SpriteRenderer>().color = _node.GetComponent<Node>().selectColor;
        //uIManager.ChangeUI(buildUI);
    }

    public void DisSelectCurrentNode()
    {
        if (currentNode == null)
        {
            return;
        }
        //currentNode.GetComponent<SpriteRenderer>().color = currentNode.GetComponent<Node>().startColor;
        //uIManager.HideUI();
        currentNode = null;
    }

    public void Building(Player player)
    {
        Debug.Log("building");
        //GameObject b = (GameObject)Instantiate(player.Base, currentNode.transform.position, Quaternion.identity);
        //currentNode.GetComponent<Node>().AddBuilding(b);
        FinishBuild();
        // if (player.money < playerManager.playerScript.Base.GetComponent<Base>().cost)
        // {
        //     Debug.Log("Dont have enough money");
        //     return;
        // }
        // if (currentNode.GetComponent<Node>().building != null)
        // {
        //     Debug.Log("there has been builded");
        //     return;
        // }
        // GameObject b = (GameObject)Instantiate(buildPrefab, currentNode.transform.position, Quaternion.identity);
        // playerManager.playerScript.money -= playerManager.playerScript.Base.GetComponent<Base>().cost;
        // currentNode.GetComponent<Node>().AddBuilding(b);
        // FinishBuild();
    }

    public void FinishBuild()
    {
        //playerManager.playerScript.actionCount++;
        //uIManager.HideUI();
        //DisSelectCurrentNode();
    }
}
