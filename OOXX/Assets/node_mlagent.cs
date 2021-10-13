using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class node_mlagent : Agent
{
    // Start is called before the first frame update
    public int winner;
    void Start()
    {
        winner = GameManager.instance.winner;
    }
}
