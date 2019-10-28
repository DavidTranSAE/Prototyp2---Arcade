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

    public void GainLife()
    {
        GetComponent<Stats>().lives++;
        Gain();
    }

    public void LoseLife()
    {
        GetComponent<Stats>().lives--;
        Lose();
    }

    private void OnBecameInvisible()
    {
        transform.position = -transform.position;
    }
}
