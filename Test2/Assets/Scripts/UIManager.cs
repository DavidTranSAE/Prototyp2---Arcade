using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Text livesText;
    public Sprite livesImage;
    List<Image> livesList = new List<Image>();

    void Start()
    {
        UpdateLives();
    }

    void Update()
    {
        
    }

    void UpdateLives()
    {
        int lives = player.GetComponent<Stats>().lives;

        for(int i = 0; i < lives; i++)
        {

        }
    }
}
