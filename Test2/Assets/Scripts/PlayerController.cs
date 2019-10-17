using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 rotateVector;
    Transform target;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   /*
        GetComponent<Player>().Move(new Vector2(Input.GetAxisRaw("P1HorizontalL"), Input.GetAxisRaw("P1VerticalL")));

        
        Vector2 moveDirection = moveVector.normalized * GetComponent<Stats>().moveSpeed;
        rbPlayer.MovePosition(rbPlayer.position + moveDirection * Time.fixedDeltaTime);
        

        get axis of joystick, rotate towards axis
        
        

        step = speed * Time.deltaTime;
        Quaternion.RotateTowards - transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        Vector3.RotateTowards - Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        
        if accelerate button is down, move forward.

        if shoot button then shoot

        */


        /*Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * GetComponent<Stats>().speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);*/

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
            GetComponent<Player>().Shoot();
        }


        

    }
}
