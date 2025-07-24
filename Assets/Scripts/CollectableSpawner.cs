using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject yellowCollectable;
    [SerializeField] private GameObject orangeCollectable;
    [SerializeField] private GameObject greenCollectable;
    [SerializeField] private GameObject blueCollectable;

    [SerializeField] private float timeBetweenNextSpawn = 5.0f;

    private float spawnPointYOffset = 3.0f;
    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        //GenerateRandomCollectable();
        if (timer >= timeBetweenNextSpawn)
        {
            GenerateRandomCollectable(GenerateRandomNumber());
            timer = 0.0f;
        }
        
        

    }

    private int GenerateRandomNumber()
    {
        int randomValue = Random.Range(0, 100);
        Debug.Log(randomValue);
        return randomValue;
    }

    private void GenerateRandomCollectable(int value)
    {
        GameObject obstacleToSpawn;

        switch (value)
        {
            case int i when i >= 0 && value <= 50:
                obstacleToSpawn = Instantiate(yellowCollectable,transform.position,Quaternion.identity);
                break; 
            case int i when i > 50 && value <= 79:
               obstacleToSpawn = Instantiate(orangeCollectable,transform.position, Quaternion.identity);
                break; 
            case int i when i > 79 && value <= 97:
                obstacleToSpawn = Instantiate(greenCollectable,transform.position, Quaternion.identity);
                break;
            case int i when i > 97 && value <= 100:
                obstacleToSpawn = Instantiate(blueCollectable,transform.position, Quaternion.identity);
                break;
            default:
                obstacleToSpawn = Instantiate(yellowCollectable,transform.position, Quaternion.identity);
                break;
        }
    }
}
