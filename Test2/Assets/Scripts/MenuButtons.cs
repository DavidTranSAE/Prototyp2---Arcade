using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button playButton;
    public Sprite playBase;
    public Sprite playEnter;
    public Sprite playPress;

    public Button exitButton;
    public Sprite exitBase;
    public Sprite exitEnter;
    public Sprite exitPress;



    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayEnter()
    {
        GetComponent<Button>().image.sprite = playEnter;
    }

    public void PlayExit()
    {
        GetComponent<Button>().image.sprite = playBase;
    }

    public void PlayPress()
    {
        GetComponent<Button>().image.sprite = playPress;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitEnter()
    {
        GetComponent<Button>().image.sprite = exitEnter;
    }

    public void ExitExit()
    {
        GetComponent<Button>().image.sprite = exitBase;
    }

    public void ExitPress()
    {
        GetComponent<Button>().image.sprite = exitPress;
    }
}