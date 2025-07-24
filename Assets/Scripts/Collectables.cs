using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    [SerializeField] int collectableValue = 0;

    private Rigidbody2D rb2D;
    private float movementSpeed = 5.0f;
    private Vector2 movementVector;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementVector = Vector2.left * movementSpeed;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = movementVector;
    }

    public int GetCollectableValue()
    {
        return collectableValue;
    }

}
