using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int health = 10;
    public int cost = 5;
    BuildOwner buildOwner;
    void Start()
    {
        buildOwner = GetComponent<BuildOwner>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Break();
        }
    }

    public void BeDameged(int damege)
    {
        health -= damege;
    }

    void Break()
    {
        buildOwner.ownerNode.GetComponent<Node>().RemoveBuilding();
        Destroy(gameObject);
    }
}
