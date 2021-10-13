using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;
    bool isMove;
    Vector3 moveTarget;

    void Start()
    {
        isMove = false;

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

    public void MoveTo(GameObject target)
    {
        isMove = true;
        moveTarget = target.transform.position;
    }
}
