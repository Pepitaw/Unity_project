using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    public GameObject selectNode;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one NodeManager");
        }
        instance = this;
    }

    void Update() {

    }

    public void SelectNode(GameObject _node){
        if(selectNode){
            selectNode.GetComponent<Node>().HideAroundNode();
        }
        selectNode=_node;
        selectNode.GetComponent<Node>().ShowAroundNode();
    }

    public void DisSelectNode(){
        selectNode.GetComponent<Node>().HideAroundNode();
        selectNode=null;
    }

}
