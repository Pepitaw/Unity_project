using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    GameObject ownerNode;
    UnitOwner unitOwner;
    Movement movement;
    UnitController unitController;
    public int health = 1;
    public int damage = 1;
    public int cost = 1;
    bool isAttacking = false;
    GameObject target;

    void Start()
    {
        ownerNode = GetComponent<UnitOwner>().ownerNode;
        unitOwner = GetComponent<UnitOwner>();
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void OccupytheNode(GameObject node)
    {
        //territoryManager.GetNode(unitOwner.player, node);
    }

    public void Attack(GameObject _target)
    {
        Debug.Log("attack");
        isAttacking = true;
        target = _target;
        movement.MoveTo(target.transform.position);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Unit>())
        {
            if (other.gameObject == target)
            {
                if (isAttacking)
                {
                    other.GetComponent<Unit>().BeDamaged(damage);
                    this.BeDamaged(other.GetComponent<Unit>().damage);
                    isAttacking = false;
                }
            }
            return;
        }

        if (other.GetComponent<Building>())
        {
            if (other.gameObject == target)
            {
                if (isAttacking)
                {
                    other.GetComponent<Building>().BeDameged(damage);
                    this.BeDamaged(damage);
                    isAttacking = false;
                }
            }
            return;
        }

        Debug.Log("Some Error");

        // if(other.gameObject==buiding){

        // }
    }

    public void BeDamaged(int damage)
    {
        health -= damage;
    }
    public void Die()
    {
        unitOwner.ownerNode.GetComponent<Node>().RemoveUnit(gameObject);
        Destroy(gameObject);
    }
}
