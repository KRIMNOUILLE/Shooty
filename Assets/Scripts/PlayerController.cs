using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float movementSpeed;

    public float playerSpeed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInput();
        MovePlayer();
        AnimatePlayer();
    }

    void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void MovePlayer()
    {
        rb.velocity = movementDirection * movementSpeed * playerSpeed;
    }

    void AnimatePlayer()
    {
        animator.SetFloat("Speed", movementSpeed);
    }
}
