using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerupPrefab;

    int spawnAmount;
    float spawnTimerCap;
    float spawnTimer;

    public Transform[] spawnPoints = new Transform[4];
    
    void Start()
    {
        spawnTimerCap = 10f;
        spawnTimer = spawnTimerCap;
    }
    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            int tempIndex = Random.Range(0, spawnPoints.Length);

            GameObject powerup = Instantiate(powerupPrefab, spawnPoints[tempIndex].position, transform.rotation);
            Destroy(powerup, 8);
            powerup.transform.parent = null;

            spawnTimer = spawnTimerCap;
        }

    }
}
