using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hovorColor;
    public Color player1SelectColor;
    public Color player2SelectColor;
    public Color aroundColor;
    public Color startColor;
    public GameObject building;
    public List<GameObject> units = new List<GameObject>();
    SpriteRenderer rend;

    public Formation formation;
    public bool hasFormated;
    public GameObject owner;
    public GameObject[] aroundNode;
    public bool isHover = false;
    public bool isSelected = false;


    void Awake()
    {
        aroundNode = new GameObject[4];
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    public void GetAroundNode(GameObject right, GameObject up, GameObject left, GameObject down)
    {
        aroundNode[0] = right;
        aroundNode[1] = up;
        aroundNode[2] = left;
        aroundNode[3] = down;
    }

    void Update()
    {

        if (units.Count == 0)
        {
            return;
        }

        if (!hasFormated)
        {
            int count = 0;
            for (int i = 0; i < units.Count; i++)
            {
                if (!units[i].GetComponent<Movement>().isMove)
                {
                    count++;
                }
            }
            if (count == units.Count)
            {
                Formating(units.Count);
            }
        }
    }

    public void AddUnit(GameObject unit)
    {
        units.Add(unit);
        unit.GetComponent<UnitOwner>().SetOwner(gameObject);
    }

    public void RemoveUnit(GameObject unit)
    {
        units.Remove(unit);
    }

    public void Formating(int num)
    {
        hasFormated = true;
        switch (num)
        {
            case 1:
                for (int i = 0; i < num; i++)
                {
                    units[i].GetComponent<Movement>().MoveTo(formation.formation1[i]);
                }
                break;
            case 2:
                for (int i = 0; i < num; i++)
                {
                    units[i].GetComponent<Movement>().MoveTo(formation.formation2[i]);
                }
                break;
            case 3:
                for (int i = 0; i < num; i++)
                {
                    units[i].GetComponent<Movement>().MoveTo(formation.formation3[i]);
                }
                break;
            case 4:
                for (int i = 0; i < num; i++)
                {
                    units[i].GetComponent<Movement>().MoveTo(formation.formation4[i]);
                }
                break;
            case 5:
                for (int i = 0; i < num; i++)
                {
                    units[i].GetComponent<Movement>().MoveTo(formation.formation5[i]);
                }
                break;
        }
    }

    public void Build(GameObject target)
    {
        //Debug.Log("building");
        GameObject b = (GameObject)Instantiate(target, transform.position, Quaternion.identity);
        building = b;
        building.GetComponent<BuildOwner>().SetOwner(gameObject);
        building.GetComponent<BuildOwner>().player = owner;
    }

    public void RemoveBuilding()
    {
        building = null;
    }

    public void BeSelected(Player player)
    {
        rend.color = player.playerColor;
        isSelected = true;
    }

    public void DisSelected(Player player)
    {
        rend.color = startColor;
        isSelected = false;
    }

    public void ShowMark(Player player, bool showORnot)
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = player.playerColor;
        transform.GetChild(0).gameObject.SetActive(showORnot);
    }

    public void ShowAroundNode()
    {
        for (int i = 0; i < 4; i++)
        {
            if (aroundNode[i] == null)
            {
                continue;
            }
            aroundNode[i].GetComponent<SpriteRenderer>().color = aroundColor;
            //Debug.Log(i);
        }
    }
    public void HideAroundNode()
    {
        for (int i = 0; i < 4; i++)
        {
            if (aroundNode[i] == null)
            {
                continue;
            }
            aroundNode[i].GetComponent<SpriteRenderer>().color = startColor;
        }
    }
}
