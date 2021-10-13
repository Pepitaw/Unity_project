using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    public Player player;

    void Start()
    {

    }
    void Update()
    {
        if (player.selectedNode == null)
        {
            return;
        }
        Node node = player.selectedNode.GetComponent<Node>();
        GameObject[] info = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            info[i] = transform.GetChild(i).gameObject;
        }
        AdjustInfo(info[0], !node.building && player.GetComponent<PlayerArea>().playersNodes.Contains(node.gameObject));
        if (node.building)
        {
            AdjustInfo(info[1], node.building.GetComponent<Base>().canProduct);
        }
        AdjustInfo(info[2], node.units.Count > 0);
    }

    public void ShowInfo()
    {
        GetComponent<CanvasGroup>().alpha = 1;
    }
    public void HideInfo()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }

    void AdjustInfo(GameObject info, bool showCondition)
    {
        info.SetActive(showCondition);
    }
}

