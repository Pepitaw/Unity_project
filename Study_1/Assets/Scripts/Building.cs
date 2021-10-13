using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;
    public void ProductUnit()
    {
        GameObject u = Instantiate(unit, transform.position, Quaternion.identity);
    }
}
