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

        GameplayController.instance.currentMaina = this;
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

    public void DropMaina()
    {
        canMove = false;
        mainaBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (gameOver)
        {
            return;
        }

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.spawnNewMaina();
        GameplayController.instance.moveCamera();
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (ignoreCollision)
            return;
        if (col.gameObject.CompareTag("Platform"))
        {
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }
        if (col.gameObject.CompareTag("Maina"))
        {
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (ignoreTrigger)
            return;
        if (col.CompareTag("GameOver"))
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame",2f);
        }


    }
} // Class