using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] Rigidbody2D playerRb2D;
    [SerializeField] float playerJumpHeight = 10.0f;

    [Header("Player Collisions")]
    [SerializeField] Collider2D playerCollider2D;
    [SerializeField] LayerMask obstacleLayers;


    bool isGrounded;
    bool canDoubleJump = false;


    private void Awake()
    {
        playerCollider2D = GetComponentInChildren<Collider2D>();
        playerRb2D = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {

        GroundedCheck();
        Damage();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (isGrounded)
            {
                playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, 0);
                playerRb2D.velocity += new Vector2(0.0f,playerJumpHeight);
                canDoubleJump = true;
            }else if (canDoubleJump)
            {
                canDoubleJump = false;
                playerRb2D.velocity = new Vector2(playerRb2D.velocity.x, 0);
                playerRb2D.velocity += new Vector2(0.0f, playerJumpHeight);
            }
        }
    }


    void GroundedCheck()
    {
        if (playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Damage()
    {
        if (playerCollider2D.IsTouchingLayers(obstacleLayers))
        {
            Debug.Log("Ouchie");
        }

    }

}
