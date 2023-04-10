/*
 * Gerard Lamoureux
 * PlayerMovement
 * Assignment 10
 * Handles player movement for a Flappy Bird Clone
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGrounded();
        Jump();
    }

    private void FixedUpdate()
    {
        MoveRight();
    }

    private void MoveRight()
    {
        if (!GameController.Instance.gameOver)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && !GameController.Instance.gameOver)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
