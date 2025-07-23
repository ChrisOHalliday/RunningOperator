using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obstaclePrefabs = new GameObject[0];
    [SerializeField]
    private float intervalTime = 5.0f;

    private float timer = 0.0f;

    private void Update()
    {

        SpawnLoop();


    }

    private void SpawnLoop()
    {

        timer += Time.deltaTime;

        if (timer >= intervalTime)
        {
            SpawnObstacle();     
            timer = 0.0f;
        }
    }

    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

        GameObject obstacleToSpawn = Instantiate(obstaclePrefabs[obstacleIndex], transform.position, Quaternion.identity);
    }

}
