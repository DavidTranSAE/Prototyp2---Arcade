using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Renderer rend;
    Vector2 offset;
    public GameObject player;

    Vector2 prev;
    Vector2 current;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        offset += player.GetComponent<Rigidbody2D>().velocity.normalized * speed * Time.deltaTime;

        rend.material.mainTextureOffset = -offset;
    }
}
