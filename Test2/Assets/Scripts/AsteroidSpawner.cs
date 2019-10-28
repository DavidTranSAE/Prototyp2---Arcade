using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    int spawnAmount;
    float spawnTimerCap;
    float spawnTimer;

    public GameObject[] spawnPoints = new GameObject[8];
    
    void Start()
    {
        spawnTimerCap = 1f;
        spawnAmount = 1;
        spawnTimer = spawnTimerCap;

    }
    
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int tempIndex = Random.Range(0, spawnPoints.Length);

                GameObject asteroid = Instantiate(asteroidPrefab, spawnPoints[tempIndex].transform.position, transform.rotation);
                asteroid.GetComponent<Asteroid>().SetDirection(spawnPoints[tempIndex].GetComponent<SpawnVector>().GetVector());
                //Destroy(asteroid, 10);
                asteroid.transform.parent = null;

                spawnTimer = spawnTimerCap;
            }


            
        }
    }
}
