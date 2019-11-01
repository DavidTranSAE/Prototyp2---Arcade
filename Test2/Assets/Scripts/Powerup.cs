using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //constant variables to reference different powerup types, each one assigned to a number
    const int SPEED = 0;
    const int LIFE = 1;
    const int SHOOT = 2;
    const int BULLET = 3;

    public Sprite speedSprite;
    public Sprite lifeSprite;
    public Sprite shootSprite;
    public Sprite bulletSprite;

    int powerupAmount = 4; //max amount of powerup types

    public int myPowerup; //the powerup type of this object

    void Start()
    {
        myPowerup = Random.Range(0, powerupAmount);
        
        if (myPowerup == SPEED)
        {
            GetComponent<SpriteRenderer>().sprite = speedSprite;
        }
        else if (myPowerup == LIFE)
        {
            GetComponent<SpriteRenderer>().sprite = lifeSprite;
        }
        else if (myPowerup == SHOOT)
        {
            GetComponent<SpriteRenderer>().sprite = shootSprite;
        }
        else if (myPowerup == BULLET)
        {
            GetComponent<SpriteRenderer>().sprite = bulletSprite;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (myPowerup == SPEED)
            {
                collision.GetComponent<Stats>().speed += 50f;
                collision.GetComponent<Stats>().rotSpeed += 0.5f;
            }
            else if (myPowerup == LIFE)
            {
                collision.GetComponent<Player>().GainLife();
            }
            else if (myPowerup == SHOOT)
            {
                collision.GetComponent<Stats>().shootCap -= 0.05f;
            }
            else if (myPowerup == BULLET)
            {
                collision.GetComponent<Stats>().bulletLevel++;
            }

            Destroy(gameObject);
        }
    }
}
