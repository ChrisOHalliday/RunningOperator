using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollisionHandler : MonoBehaviour
{
    //Health
    private const int maxPlayerHealth = 3;
    private int playerHealth = maxPlayerHealth;
    
    [SerializeField]
    private Sprite healthSprite;
    
    [SerializeField]
    private Image[] healthIcons = new Image[maxPlayerHealth];

    private bool isAlive = true;

    //Collectables
    private int score;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    private void Update()
    {
        CheckAliveStatus();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAlive)
        {
            if (collision.tag == "Obstacle")
            {
                playerHealth--;
                UpdateHealthIcons();
                //Debug.Log(playerHealth);
            }

            if (collision.tag == "Collectable")
            {
                Collectables collectable = collision.GetComponent<Collectables>();

                score += collectable.GetCollectableValue();
                UpdateScoreText();
                //Debug.Log(score);
                Destroy(collision.gameObject);
            }
        }
        else { return; }
    }

    #region Health

    private void CheckAliveStatus()
    {
        if (playerHealth <= 0 && isAlive)
        {
            isAlive = false;
        }

        if (!isAlive)
        {

            
        }
    }
    private void UpdateHealthIcons()
    {

        healthIcons[playerHealth].sprite = healthSprite;

    }
    #endregion


    #region Collectables

    private void UpdateScoreText()
    {
        string scoreString = "Score: " + score.ToString();
        scoreText.text = scoreString;
    }


    #endregion

}
