using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] Rigidbody2D playerRb2D;
    [SerializeField] float playerMoveSpeed = 20.0f;
    [SerializeField] float playerJumpHeight = 10.0f;

    [Header("Player Collisions")]
    [SerializeField] Collider2D playerCollider2D;
    [SerializeField] LayerMask obstacleLayers;

    [Header("Player Camera Bounds")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;

    int numOfJumps = 2;
    bool isGrounded;
    bool canDoubleJump = false;

    //Vector2 moveVelocity;
    Vector2 playerRawInput;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Awake()
    {
        playerCollider2D = GetComponent<Collider2D>();
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //InitBounds();
    }

    void Update()
    {

        //moveVelocity = new Vector2(1.0f * playerMoveSpeed, playerRb2D.velocity.y);
        //playerRb2D.velocity = moveVelocity;


        //Vector2 newClampedPosVector = new Vector2();

        //newClampedPosVector.x = Mathf.Clamp(transform.position.x + moveVector.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        //newClampedPosVector.y = Mathf.Clamp(transform.position.y + moveVector.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        //playerRb2D.velocity = new Vector2(playerRawInput.x * playerMoveSpeed * Time.deltaTime,playerRb2D.velocity.y);

        
        GroundedCheck();
        Damage();
    }

    //void InitBounds()
    //{
    //    Camera mainCamera = Camera.main;
    //    minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
    //    maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    //}

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

    private void OnMove(InputValue value)
    {
        playerRawInput = value.Get<Vector2>();
        Debug.Log(playerRawInput);    
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
