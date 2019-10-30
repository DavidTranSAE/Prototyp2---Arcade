using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public delegate void Life();
    public static event Life Lose;
    public static event Life Gain;

    private void OnEnable()
    {
        Asteroid.Add += AddScore;
    }

    private void OnDisable()
    {
        Asteroid.Add -= AddScore;
    }

    void Update()
    {
        /*if (Input.GetKeyDown("e"))
        {
            GetComponent<Stats>().score += 100;
        }*/
    }

    public void Shoot()
    {
        if (GetComponent<Stats>().shootTimer <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(transform.up * 50f);
            Destroy(bullet, 3);
            bullet.transform.parent = null;

            GetComponent<Stats>().shootTimer = GetComponent<Stats>().shootCap;
        }
    }

    public void ShootLaser()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, transform.up, 100f);
        
        for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.tag == "Asteroid")
            {
                hit[i].collider.GetComponent<Asteroid>().DestroyThisAsteroid();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            LoseLife();
        }
    }

    void AddScore(int score)
    {
        GetComponent<Stats>().score += score;
    }

    //This changes the life stat and also triggers the Gain event which will allow other scripts that are listening to that event to do certain things when a player gains life
    //UIManager listens to this event so that the life UI gets updated accordingly
    public void GainLife()
    {
        GetComponent<Stats>().lives++;
        Gain();
    }

    //Same as above
    public void LoseLife()
    {
        GetComponent<Stats>().lives--;
        Lose();
    }

    //Rough way to make the player appear on other side of screen once off.
    private void OnBecameInvisible()
    {
        transform.position = -transform.position;

    }
}
