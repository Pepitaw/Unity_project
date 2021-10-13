using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOwner : MonoBehaviour
{
    public GameObject ownerNode;
    public GameObject player;

    public void SetOwner(GameObject node)
    {
        ownerNode = node;
    }
}
