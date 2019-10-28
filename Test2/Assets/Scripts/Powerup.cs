using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    const int SPEED = 0;
    const int LIFE = 1;
    const int SHOOT = 2;

    int powerupAmount = 3;

    public int myPowerup;



    // Start is called before the first frame update
    void Start()
    {
        myPowerup = Random.Range(0, powerupAmount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (myPowerup == SPEED)
            {
                collision.GetComponent<Stats>().speed += 50f;
                collision.GetComponent<Stats>().rotSpeed += 0.5f;
                Debug.Log(myPowerup);
            }
            else if (myPowerup == LIFE)
            {
                collision.GetComponent<Player>().GainLife();
                Debug.Log(myPowerup);
            }
            else if (myPowerup == SHOOT)
            {
                collision.GetComponent<Stats>().shootCap -= 0.05f;
                Debug.Log(myPowerup);
            }

            Destroy(gameObject);
        }
    }
}
