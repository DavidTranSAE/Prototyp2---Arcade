using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Vector2 direction;
    public float scale = 3;
    float speed;
    Rigidbody2D rb;
    int deathSpawn = 2; //num of asteroids spawned upon death


    public delegate void Score(int score);
    public static event Score Add;

    void Awake()
    {
        //speed = 5f;
        speed = Random.Range(3, 8);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.MovePosition(rb.position += direction * speed * Time.deltaTime);
    }

    public void SetDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    public void SetDirection(Vector2 inDirection)
    {
        direction = inDirection;
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(scale, scale, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision);

            if (scale > 1)
            {
                for (int i = 0; i < deathSpawn; i++)
                {
                    GameObject asteroid = Instantiate(gameObject, transform.position, transform.rotation);

                    if (i == 0)
                    {
                        asteroid.GetComponent<Asteroid>().SetDirection(collision.transform.right);
                    }
                    else
                    {
                        asteroid.GetComponent<Asteroid>().SetDirection(collision.transform.right * -1);
                    }

                    
                    asteroid.GetComponent<Asteroid>().scale--;
                    asteroid.GetComponent<Asteroid>().SetScale();

                    Destroy(asteroid, 10);
                    asteroid.transform.parent = null;
                }
            }

            Destroy(gameObject);

            Add((int)(100 * speed / scale));
        }
    }
}
