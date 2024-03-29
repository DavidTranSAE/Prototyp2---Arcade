﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    //public GameObject asteroidSpawner;
    public GameObject particlePrefab;

    private void OnEnable()
    {
        Player.Lose += LoseLife;
    }

    private void OnDisable()
    {
        Player.Lose -= LoseLife;
    }

    void LoseLife()
    {
        GameObject reference = (GameObject)Instantiate(particlePrefab, player.transform.position, Quaternion.identity);
        Destroy(reference, 1f);
        if (player.GetComponent<Stats>().lives > 0)
        {
            player.SetActive(false);
            StartCoroutine(Death());
            
        }
        else
        {
            player.SetActive(false);
            StartCoroutine(GameOver());

        }
    }

    //on player death
    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);

        GameObject[] allAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        for(int i = 0; i < allAsteroids.Length; i++)
        {
            Destroy(allAsteroids[i].gameObject);
        }

        player.SetActive(true);
        player.transform.position = new Vector3(0, 0, 0);
        //asteroidSpawner.GetComponent<AsteroidSpawner>().RemoveAll();
    }

    //on player death with no more lives
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        
    }
}
