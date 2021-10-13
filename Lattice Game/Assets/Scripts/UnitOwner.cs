using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOwner : MonoBehaviour
{
    public GameObject player;
    public GameObject ownerNode;

    public void SetOwner(GameObject node){
        ownerNode=node;
    }    
}
