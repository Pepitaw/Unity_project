using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    Player player;
    public GameObject baseUI;
    public BuildOwner buildOwner;

    [Header("Prefabs")]
    public GameObject worker;

    public bool canProduct = false;

    void Start()
    {
        buildOwner = GetComponent<BuildOwner>();
    }

    void Update()
    {
        if (buildOwner.ownerNode.GetComponent<Node>().units.Count >= 5)
        {
            canProduct = false;
        }
        else
        {
            canProduct = true;
        }
    }

    public void ProductWorker()
    {
        if (!canProduct)
        {
            return;
        }
        if (!(buildOwner.player.GetComponent<Player>().money >= worker.GetComponent<Unit>().cost))
        {
            return;
        }

        buildOwner.player.GetComponent<Player>().money -= worker.GetComponent<Unit>().cost;
        GameObject w = (GameObject)Instantiate(worker, transform.position, Quaternion.identity);
        w.GetComponent<UnitOwner>().player = buildOwner.player;
        buildOwner.ownerNode.GetComponent<Node>().AddUnit(w);
        buildOwner.ownerNode.GetComponent<Node>().hasFormated = false;
    }
}
