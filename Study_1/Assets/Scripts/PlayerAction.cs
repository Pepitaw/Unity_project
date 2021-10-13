using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Node selectedNode;

    void Start()
    {
        selectedNode = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
        if (Input.GetMouseButtonDown(1))
        {
            AttempToMove();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            AttempToBuild(0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AttempToProduct();
        }
    }
    private void Select()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Node node = hit.transform.GetComponent<Node>();
            if (node != null)
            {
                if (selectedNode != node)
                {
                    if (selectedNode != null)
                        selectedNode.DisSelect();
                    selectedNode = node;
                    selectedNode.BeSelect();
                }
                else
                {
                    selectedNode.DisSelect();
                    selectedNode = null;
                }
                Debug.Log("select");
            }
        }
    }

    private void AttempToBuild(int buildingIndex)
    {
        if (selectedNode != null)
        {
            selectedNode.Build(buildingIndex);
        }
    }

    private void AttempToProduct()
    {
        if (selectedNode != null)
        {
            if (selectedNode.buildingOnIt != null)
            {
                Building b = selectedNode.buildingOnIt.GetComponent<Building>();
                b.ProductUnit();
            }
        }
    }

    private void AttempToMove()
    {
        if (selectedNode != null)
        {

        }
    }
}
