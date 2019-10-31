using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Image livesImage;
    public Image livesImagePrefab;
    public Transform livesPos;
    List<Image> livesList = new List<Image>(); //list of lives images to show on the UI

    private void OnEnable()
    {
        Player.Gain += GainLife;
        Player.Lose += LoseLife;
    }

    private void OnDisable()
    {
        Player.Gain -= GainLife;
        Player.Lose -= LoseLife;
    }

    void Start()
    {
        for (int i = 0; i < player.GetComponent<Stats>().lives; i++)
        {
            Image newImage = Instantiate(livesImagePrefab, livesImage.transform);
            livesList.Add(newImage);
        }

        UpdateLife();
    }

    void Update()
    {
        scoreText.text = player.GetComponent<Stats>().score.ToString();
    }

    //update lives UI to show the correct amount
    void UpdateLife()
    {
        for (int i = 0; i < livesList.Count; i++)
        {
            livesList[i].transform.position = livesPos.position + new Vector3(40 * i, 0, 0);
        }
    }

    void GainLife()
    {
        livesList.Add(Instantiate(livesImagePrefab, livesImage.transform));
        UpdateLife();
    }

    void LoseLife()
    {
        if(livesList.Count > 0)
        {
            Destroy(livesList[0].gameObject);
            livesList.RemoveAt(0);
            UpdateLife();
        }
    }
}
