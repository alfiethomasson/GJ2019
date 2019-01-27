﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement2 : MonoBehaviour
{

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20;
    public float turnSpeed = 20;
    public bool InGame;
    public AudioClip footstep;
    AudioSource source;
    int layerMask;
    bool wall;

    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        InGame = false;
        source = GetComponent<AudioSource>();
        source.clip = footstep;
        source.loop = true;
        source.volume = 1.0f;
        layerMask = LayerMask.GetMask("Wall");
        wall = false;
        

    }

    void Update()
    {       

    }

    void FixedUpdate()
    {


        horizontal = Input.GetAxisRaw("CleanHorizontal");
        vertical = Input.GetAxisRaw("CleanVertical");

        if (InGame == false)
        {
            Vector2 moveVec = new Vector2(horizontal, vertical) * runSpeed;
            body.AddForce(moveVec);
            source.Play();

            if (moveVec != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveVec), Time.fixedDeltaTime * turnSpeed);
                source.Play();
            }

            if (horizontal != 0 && vertical != 0)
            {
                body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
                source.Play();
            }
            else
            {
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
                source.Stop();
            }
        }

    }
}
