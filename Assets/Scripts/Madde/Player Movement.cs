using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform GFX;
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
    [SerializeField] private GameObject clickToStart;

    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isCrouching = false; // Ny bool för att hantera crouch-state
    private float jumpTimer;
    private bool gameStarted = false;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D capsuleCollider;
    

    private void Start()
    {
        Time.timeScale = 0f; // Pausar spelet
        clickToStart.SetActive(true); // Visar "Click to Start"-bilden
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        
    }

    private void Update()
    {

        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0)) // Kollar om spelaren klickar
            {
                StartGame();
            }
            return; // Hindrar resten av Update från att köra innan spelet startar
        }

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
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 0.9f);

        }

        if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 1.8f);
        }

        if (isJumping && Input.GetButton("Crouch"))
        {
            isCrouching = false;
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 1.8f);
        }

        if (Input.GetButtonUp("Crouch") && canStandUp)
        {
            isCrouching = false;
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, 1.8f);

        }
        animator.SetFloat("MoveSpeed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetFloat("VerticalSpeed", rigidBody.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Spelaren springer automatiskt framåt
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f; // Startar spelet
        clickToStart.SetActive(false); // Döljer "Click to Start"-bilden
    }

}