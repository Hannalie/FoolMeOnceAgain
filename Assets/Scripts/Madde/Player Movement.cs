using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask ceilingLayer; // Nytt för att kolla hinder ovanför
    [SerializeField] private Transform feetPos;
    [SerializeField] private Transform headPos; // Nytt för att kolla takhöjd
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float headCheckDistance = 0.25f; // Avstånd för att kolla tak
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float normalHeight = 1f; // För att lättare hantera skalan

    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isCrouching = false; // Ny bool för att hantera crouch-state
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);
        bool canStandUp = !Physics2D.OverlapCircle(headPos.position, headCheckDistance, ceilingLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        
        if (isGrounded && Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            
        }

        if (isJumping && Input.GetButton("Crouch"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        }

        if (Input.GetButtonUp("Crouch") && canStandUp)
        {
            isCrouching = false;
            GFX.localScale = new Vector3(GFX.localScale.x, normalHeight, GFX.localScale.z);
            
        }
    }

    void FixedUpdate()
    {
        // Spelaren springer automatiskt framåt
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}