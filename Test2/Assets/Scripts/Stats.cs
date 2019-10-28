using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public int lives;
    public int score;


    public float shootCap;
    public float shootTimer;
    
    void Start()
    {
        speed = 300f;
        rotSpeed = 4f;
        lives = 3;
        shootCap = 0.75f;
    }
    
    void Update()
    {
        shootTimer -= Time.deltaTime;
    }
}
