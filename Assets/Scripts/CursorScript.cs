using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    [SerializeField] private LayerMask layers;
    [SerializeField] private float homingRadius = 5.0f;
    [SerializeField] private string[] collisionTags = { "Ground", "Player" };
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float rotationSpeed = 50.0f;

    private ObjectMovement movement;
    private Rigidbody2D rb2D;
    private Collider2D target;
    private bool lockedIn = false;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        movement = GetComponent<ObjectMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collisionTags.Contains(collision.tag))
        {             
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (CheckForPlayerInRadius())
        {
            CursorHoming();
        }
    }
    private bool CheckForPlayerInRadius()
    {

        target = Physics2D.OverlapCircle(transform.position, homingRadius, layers);

        if (target != null)
        {           
            Debug.Log(target.tag);
            return true;
        }

        return false;
    }

    private void CursorHoming()
    {
        movement.enabled = false;
        rb2D.gravityScale = 0.0f;

        if (!lockedIn)
        {
            Vector3 directionVector = target.transform.position - transform.position;
            Vector3 rotationdirectionVector = transform.position - target.transform.position;
            Vector3 normalizedMovementVector = directionVector.normalized;

            Quaternion rotation = Quaternion.LookRotation(Vector3.forward,rotationdirectionVector);
            transform.rotation = Quaternion.Lerp(transform.rotation,rotation, rotationSpeed * Time.deltaTime);
            
            rb2D.velocity = normalizedMovementVector * speed * Time.deltaTime;
            lockedIn = true;
        }


    }

    #region gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (CheckForPlayerInRadius())
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireSphere(transform.position, homingRadius);
    }

    #endregion
}
