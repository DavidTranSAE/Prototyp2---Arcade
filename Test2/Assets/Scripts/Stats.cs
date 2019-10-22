using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        speed = 200f;
        rotSpeed = 4f;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
