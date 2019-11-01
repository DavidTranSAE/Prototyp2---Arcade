using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;
    public bool advanced = false;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        speed = 15f;

        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("advanced", advanced);

        if(advanced)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
