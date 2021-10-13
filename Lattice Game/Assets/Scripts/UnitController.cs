using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitController : MonoBehaviour
{
    public List<GameObject> units;

    [HideInInspector]
    public bool isSelectedUnits = false;
    Player player;
    PlayerArea playerArea;

    void Start()
    {
        units = new List<GameObject>();
        player = GetComponent<Player>();
        playerArea = GetComponent<PlayerArea>();
    }

    public void SelectUnits(List<GameObject> _units)
    {
        //playerArea.ShowSurroundNodes();
        isSelectedUnits = true;
        for (int i = 0; i < _units.Count; i++)
        {
            if (_units[i].tag == player.tag && !units.Contains(_units[i]))
            {

                units.Add(_units[i]);
            }
        }
    }
    public void DisSelectUints()
    {
        playerArea.HideSurroundNodes();
        isSelectedUnits = false;
        units.Clear();
    }

    public void MoveUnitsToNode(GameObject node)
    {
        Node n = node.GetComponent<Node>();
        n.hasFormated = false;

        if (units.Count == 0)
        {
            return;
        }

        if (n.owner == null)
        {
            //occupy and move
            int num = Mathf.Max(0, units.Count - n.units.Count);
            for (int i = 0; i < num; i++)
            {
                units[i].GetComponent<Movement>().MoveTo(node.transform.position);
                units[i].GetComponent<UnitOwner>().ownerNode.GetComponent<Node>().RemoveUnit(units[i]);
                n.AddUnit(units[i]);
                n.hasFormated = false;
            }
            n.owner = player.gameObject;
            DisSelectUints();
            return;
        }

        if (n.owner == player.gameObject)
        {
            //move)
            for (int i = 0; i < units.Count; i++)
            {
                if (n.units.Count == 5)
                {
                    player.selectedNode.GetComponent<Node>().hasFormated = false;
                    break;
                }
                units[i].GetComponent<Movement>().MoveTo(node.transform.position);
                units[i].GetComponent<UnitOwner>().ownerNode.GetComponent<Node>().RemoveUnit(units[i]);
                n.AddUnit(units[i]);
                n.hasFormated = false;
            }
            DisSelectUints();
            return;
        }

        if (n.owner != player.gameObject)
        {
            AttackNode(node);
            DisSelectUints();
            return;
        }


        // if (node.GetComponent<Node>().owner == units[0].GetComponent<UnitOwner>().player || node.GetComponent<Node>().owner == null)
        // {
        //     //normal movemoment
        //     for (int i = 0; i < units.Count; i++)
        //     {
        //         if (node.GetComponent<Node>().units.Count < 5)
        //         {
        //             units[i].GetComponent<Movement>().MoveTo(node.transform.position);
        //             units[i].GetComponent<UnitOwner>().ownerNode.GetComponent<Node>().RemoveUnit(units[i]);
        //             //units[i].GetComponent<Unit>().OccupytheNode(node);
        //             node.GetComponent<Node>().AddUnit(units[i]);
        //         }
        //         else
        //         {
        //             units[i].GetComponent<UnitOwner>().ownerNode.GetComponent<Node>().hasFormated = false;
        //         }
        //     }
        // }
        // else
        // {
        //     //attack
        //     AttackNode(node);
        // }

        // DisSelectUints();
    }

    void AttackNode(GameObject node)
    {
        Node n = node.GetComponent<Node>();
        if (n.units.Count == 0)
        {
            if (n.building)
            {
                foreach (var unit in units)
                {
                    unit.GetComponent<Unit>().Attack(n.building);
                }
                return;
            }
            node.GetComponent<Node>().owner = player.gameObject;
            MoveUnitsToNode(node);
            return;
        }

        int i = 0;
        while (i < node.GetComponent<Node>().units.Count && i < units.Count)
        {
            GameObject target = node.GetComponent<Node>().units[i];
            units[i].GetComponent<Unit>().Attack(target);
            i++;
        }

        if (units.Count > node.GetComponent<Node>().units.Count)
        {

        }
    }
}
