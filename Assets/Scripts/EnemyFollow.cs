using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;
    private Transform target;
    private SpriteRenderer enemySprite;
    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FlipEnemy();
        if (Vector3.Distance(transform.position, target.position) > 1)
        {
            enemyAnimator.SetFloat("Speed", 1);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            enemyAnimator.SetFloat("Speed", 0);
        }
    }

    void FlipEnemy()
    {
        if (transform.position.x >= target.position.x)
        {
            enemySprite.flipX = false;
        }
        else
        {
            enemySprite.flipX = true;
        }
    }
}