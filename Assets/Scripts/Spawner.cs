using System.Collections;
using System.Collections.Generic;
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

        timer += Time.deltaTime;

        if (timer >= intervalTime)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            Instantiate(obstaclePrefabs[obstacleIndex], transform.position, Quaternion.identity);

            timer = 0.0f; 
        }

    }


}
