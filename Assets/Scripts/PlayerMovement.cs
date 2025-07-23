using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private Rigidbody2D playerRb2D;
    [SerializeField] private float playerJumpHeight = 10.0f;
    [SerializeField] private float playerUpscaledGravity = 15.0f;

    [Header("Player Collisions")]
    [SerializeField] Collider2D playerCollider2D;
    [SerializeField] LayerMask obstacleLayers;

    private PlayerInput playerInputActions;

    private float playerDefaultGravityScale;
    private bool isGrounded;
    private bool canDoubleJump = false;

    private void Awake()
    {
        playerCollider2D = GetComponentInChildren<Collider2D>();
        playerRb2D = GetComponentInChildren<Rigidbody2D>();

        playerInputActions = new PlayerInput();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += OnJump;
        playerInputActions.Player.Fall.performed += OnFastFall;

    }

    private void Start()
    {
        playerDefaultGravityScale = playerRb2D.gravityScale;
    }

    private void Update()
    {
        GroundedCheck();
    }

    #region Jump

    private void OnJump(InputAction.CallbackContext context)
    {

        ProcessJump();
    }

    private void ProcessJump()
    {

        if (isGrounded)
        {
            playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, 0);
            playerRb2D.velocity += new Vector2(0.0f, playerJumpHeight);
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, 0);
            playerRb2D.velocity += new Vector2(0.0f, playerJumpHeight*0.75f);
        }
    }

    private void GroundedCheck()
    {
        if (playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
            playerRb2D.gravityScale = playerDefaultGravityScale;
        }
        else
        {
            isGrounded = false;
        }
    }

    #endregion


    #region Fast Fall

    private void OnFastFall(InputAction.CallbackContext context)
    {
        if (!isGrounded)
        {
            playerRb2D.gravityScale = playerUpscaledGravity;
            canDoubleJump = false;
        }
    }



    #endregion

}
