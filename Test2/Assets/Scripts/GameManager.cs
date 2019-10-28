using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

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

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        player.transform.position = new Vector3(0, 0, 0);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        
    }
}
