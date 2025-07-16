using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed  = 5;
    private Vector3 movementVector;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementVector = Vector3.left * speed;
    }


    private void FixedUpdate()
    {
        
        rb2D.velocity = movementVector;
    }
}
