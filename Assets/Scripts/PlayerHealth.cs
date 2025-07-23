using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private const int maxPlayerHealth = 3;

    private int playerHealth = maxPlayerHealth;

    [SerializeField]
    private Sprite healthSprite;

    [SerializeField]
    private Image[] healthIcons = new Image[maxPlayerHealth];


    private bool isAlive = true;

    private void Update()
    {
        CheckAliveStatus();

    }

    private void CheckAliveStatus()
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
            UpdateHealthIcons();
            Debug.Log(playerHealth);
        }
    }

    private void UpdateHealthIcons()
    {

        healthIcons[playerHealth].sprite = healthSprite;

    }
}
