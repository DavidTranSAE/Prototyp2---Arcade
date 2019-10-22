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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            GetComponent<Stats>().score += 100;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.up * 50f);
        Destroy(bullet, 3);
        bullet.transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            Lose();
        }
    }

    void AddScore(int score)
    {
        GetComponent<Stats>().score += score;
    }
}
