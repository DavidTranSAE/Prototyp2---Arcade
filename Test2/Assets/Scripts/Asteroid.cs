using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidSpawner;

    Vector2 direction;
    public float scale = 3; //The original scale of the object. It is first 3 times the size and then gets smaller as it gets destroyed.
    float speed;
    Rigidbody2D rb;
    int deathSpawn = 2; //num of asteroids spawned upon death


    public delegate void Score(int score);
    public static event Score Add;

    void Awake()
    {
        speed = Random.Range(4, 7);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //asteroidSpawner.GetComponent<AsteroidSpawner>().AddToList(gameObject);
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
            Destroy(collision.gameObject);

            //if the asteroid is large, it breaks down
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

                    //reduce the size of the spawned asteroid
                    asteroid.GetComponent<Asteroid>().scale--;
                    asteroid.GetComponent<Asteroid>().SetScale();

                    asteroid.transform.parent = null;
                }
            }

            DestroyThisAsteroid();

            //Triggers the add event which gives out a value based on the speed of the asteroid destroyed and the scale of it.
            Add((int)(100 * speed / scale));
        }
    }

    private void OnBecameInvisible()
    {
        DestroyThisAsteroid();
    }

    public void DestroyThisAsteroid()
    {
        //asteroidSpawner.GetComponent<AsteroidSpawner>().RemoveFromList(gameObject);
        Destroy(gameObject);
    }
}
