using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 rotateVector;
    Transform target;
    Rigidbody2D rb;

    bool shoot = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(transform.up * GetComponent<Stats>().speed * Time.deltaTime);
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * GetComponent<Stats>().rotSpeed * -1), Space.Self);
        }
         
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * GetComponent<Stats>().rotSpeed * -1), Space.Self);
        }

        if (Input.GetKeyDown("space"))
        {
            if(shoot)
            {
                GetComponent<Player>().Shoot();
                shoot = false;
            }
            else
            {
                GetComponent<Player>().ShootLaser();
                //shoot = true;
            }
            
        }
    }
}
