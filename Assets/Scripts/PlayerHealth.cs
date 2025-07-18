using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int playerHealth = 3;
    private bool isAlive = true;

    private void Update()
    {
        if (playerHealth <= 0 && isAlive)
        {            
            isAlive = false;
        }

        if (!isAlive)
        {

            Debug.Log("Dead");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && isAlive)
        {
            playerHealth--;
            Debug.Log(playerHealth);
        }
    }

}
