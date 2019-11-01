using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    public delegate void Life();
    public static event Life Lose;
    public static event Life Gain;

    public Transform[] bulletPos;
    const int MIDDLE = 0;
    const int LEFT = 1;
    const int RIGHT = 2;

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
        if (Input.GetKeyDown("e"))
        {
            GetComponent<Stats>().bulletLevel++;
        }
    }

    public void Shoot()
    {
        if (GetComponent<Stats>().shootTimer <= 0)
        {
            if(GetComponent<Stats>().bulletLevel != 2 && GetComponent<Stats>().bulletLevel != 5)
            {
                ShootMiddle();
            }

            if(GetComponent<Stats>().bulletLevel != 1 && GetComponent<Stats>().bulletLevel != 4)
            {
                ShootLeft();
                ShootRight();
            }
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


        /*if(Mathf.Abs(0 - transform.position.y) > Mathf.Abs(0 - transform.position.x))
        {
            transform.position = new Vector3(transform.position.x, -transform.position.x, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(-transform.position.x, transform.position.x, transform.position.z);
        }*/

    }

    void ShootMiddle()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos[MIDDLE].position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.up * 50f);
        Destroy(bullet, 3);
        bullet.transform.parent = null;

        GetComponent<Stats>().shootTimer = GetComponent<Stats>().shootCap;

        CheckAdvanced(bullet);

    }

    void ShootLeft()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos[LEFT].position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.up * 50f);
        Destroy(bullet, 3);
        bullet.transform.parent = null;

        GetComponent<Stats>().shootTimer = GetComponent<Stats>().shootCap;

        CheckAdvanced(bullet);
    }

    void ShootRight()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos[RIGHT].position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.up * 50f);
        Destroy(bullet, 3);
        bullet.transform.parent = null;

        GetComponent<Stats>().shootTimer = GetComponent<Stats>().shootCap;

        CheckAdvanced(bullet);
    }

    void CheckAdvanced(GameObject bullet)
    {
        if(GetComponent<Stats>().bulletLevel > 3)
        {
            bullet.GetComponent<Bullet>().advanced = true;
        }
    }
}
