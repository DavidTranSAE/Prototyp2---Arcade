using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        /*

        Player stats:
        speed
        health
        score

        bullet







        */
        speed = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.up * 50f);
        Destroy(bullet, 3);
        bullet.transform.parent = null;
    }
}
