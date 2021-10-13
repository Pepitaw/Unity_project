using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public int health;
    Vector3 moveTarget;
    public bool isMove = false;

    void Start()
    {

    }
    void Update()
    {
        if (!isMove)
        {
            return;
        }
        Vector2 dir = moveTarget - transform.position;
        if (Vector2.Distance(moveTarget, transform.position) < 0.05f)
        {
            isMove = false;
            return;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    public void MoveTo(Vector2 target)
    {
        isMove = true;
        moveTarget = target;
    }

    void OnMouseDown()
    {

    }
}
