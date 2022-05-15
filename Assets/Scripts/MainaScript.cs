using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class MainaScript : MonoBehaviour
{
    [SerializeField] private float minX = -2.09f;
    [SerializeField] private float maxX = 2.09f;

    private bool canMove;
    private float moveSpeed = 2f;
    private Rigidbody2D mainaBody;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    private void Awake()
    {
        mainaBody = GetComponent<Rigidbody2D>();
        mainaBody.gravityScale = 0f;
    }

    private void Start()
    {
        canMove = true;

        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1f;
        }
    }

    private void Update()
    {
        MoveMaina();
    }


    void MoveMaina()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;

            if (temp.x > maxX)
            {
                moveSpeed *= -1f;
            }else if (temp.x < minX)
            {
                moveSpeed *= -1f;
            }
            
            transform.position = temp;
        }
    }
} // Class