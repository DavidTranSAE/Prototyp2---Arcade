using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    int spawnAmount;
    float spawnTimerCap;
    float spawnTimer;
    float difficultyTimer;

    public GameObject[] spawnPoints = new GameObject[8];
    //List<GameObject> allAsteroids;
    
    void Start()
    {
        spawnTimerCap = 1f;
        spawnAmount = 1;
        spawnTimer = spawnTimerCap;
        difficultyTimer = 0;
    }
    
    void Update()
    {
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer > 30)
        {
            spawnAmount++;
            Debug.Log("Difficulty Increased");
            difficultyTimer = 0;
        }
        


        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                int tempIndex = Random.Range(0, spawnPoints.Length);

                GameObject asteroid = Instantiate(asteroidPrefab, spawnPoints[tempIndex].transform.position, transform.rotation);
                asteroid.GetComponent<Asteroid>().SetDirection(spawnPoints[tempIndex].GetComponent<SpawnVector>().GetVector());
                asteroid.transform.parent = null;

                //asteroid.GetComponent<Asteroid>().asteroidSpawner = gameObject;

                spawnTimer = spawnTimerCap;
            }


            
        }
    }

    /*public void AddToList(GameObject asteroid)
    {
        allAsteroids.Add(asteroid);
    }

    public void RemoveFromList(GameObject asteroid)
    {
        allAsteroids.Remove(asteroid);
    }

    public void RemoveAll()
    {
        for (int i = 0; i < allAsteroids.Count; i++)
        {
            Destroy(allAsteroids[i].gameObject);
        }

        allAsteroids.Clear();
    }*/
}
