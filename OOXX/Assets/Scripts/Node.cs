using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField]
    private Color oColor;
    [SerializeField]
    private Color xColor;
    public int state;// 0 1 2
    void Start()
    {
        gameManager = GameManager.instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        state = 0;
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (spriteRenderer.color != originalColor)
        {
            return;
        }
        if (gameManager.currentTurn == 0)
        {
            state = 1;
            spriteRenderer.color = oColor;
            gameManager.ChanageTurn();
        }

        else if (gameManager.currentTurn == 1)
        {
            state = 2;
            spriteRenderer.color = xColor;
            gameManager.ChanageTurn();
        }
        else
            Debug.LogError("some error happened");
    }
}
