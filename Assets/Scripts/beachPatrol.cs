using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beachPatrol : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Transform[] patrolPoint;
    private int curPoint = 0;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(transform.position == patrolPoint[curPoint].position)
        {
            curPoint++;
        }
        if(curPoint >= patrolPoint.Length)
        {
            curPoint = 0;
        }
        Vector3 movPos = Vector3.MoveTowards(transform.position, patrolPoint[curPoint].position, moveSpeed * Time.deltaTime);
        transform.position = movPos;
    }
}
