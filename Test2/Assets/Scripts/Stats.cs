using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int lives;
    public int score;
    public int bulletLevel;

    public float speed;
    public float rotSpeed;

    


    public float shootCap;
    public float shootTimer;

    
    void Start()
    {
        speed = 300f;
        rotSpeed = 4f;
        lives = 3;
        shootCap = 0.75f;
        bulletLevel = 1;
    }
    
    void Update()
    {
        shootTimer -= Time.deltaTime;
    }
}
