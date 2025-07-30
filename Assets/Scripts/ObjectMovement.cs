using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed  = 5.0f;
    private Vector2 movementVector;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementVector = Vector2.left * speed;
    }


    private void FixedUpdate()
    {
        
        rb2D.velocity = movementVector;
    }
}
