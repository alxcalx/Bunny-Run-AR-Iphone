﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BunnyController : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0F;
    public float rotationspeed = 200.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          float translation = Input.GetAxis("Vertical") * speed;
          float rotation = Input.GetAxis("Horizontal") * rotationspeed;
          translation *= Time.deltaTime;
           rotation *= Time.deltaTime;
          transform.Translate(0, 0, translation);
          transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");

        }
        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);

        }
    }

    public void Jump()
    {
        anim.SetTrigger("isJumping");

    }

}
