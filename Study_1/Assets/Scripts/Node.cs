using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color idleColor;
    [SerializeField]
    private Color selectedColor;

    [SerializeField]
    private GameObject building1;

    public GameObject buildingOnIt;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        spriteRenderer.color = idleColor;
        buildingOnIt = null;
    }
    public void BeSelect()
    {
        spriteRenderer.color = selectedColor;
    }

    public void DisSelect()
    {
        spriteRenderer.color = idleColor;
    }

    public void Build(int buildingIndex)
    {
        GameObject b = Instantiate(building1, transform.position, Quaternion.identity);
        buildingOnIt = b;
    }
}
