using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    int spawnAmount;
    float spawnTimerCap;
    float spawnTimer;

    public Transform[] spawnPoints = new Transform[4];

    // Start is called before the first frame update
    void Start()
    {
        spawnTimerCap = 0.5f;
        spawnAmount = 1;
        spawnTimer = spawnTimerCap;

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            asteroid.GetComponent<Asteroid>().SetDirection();
            Destroy(asteroid, 10);
            asteroid.transform.parent = null;

            spawnTimer = spawnTimerCap;
        }
    }
}
