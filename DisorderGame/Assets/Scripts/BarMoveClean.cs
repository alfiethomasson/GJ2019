﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BarMoveClean : MonoBehaviour {

    Vector3 pointA;
    Vector3 pointB;
    bool cdavailable = false;
    bool finished = false;

    public float barSpeed = 10.0f;

    void start()
    {
    }

    void OnEnable()
    {

            pointA = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            pointB = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            transform.position = GameObject.Find("SliderClean").transform.position;
            
        }



    void Update () {
        float time = Mathf.PingPong(Time.time * barSpeed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

        if(Input.GetKeyDown("enter"))
        {
            finished = false;
            if (cdavailable == true)
            {
                GameObject.Find("PlayerClean").GetComponent<CleanInteraction>().SliderDisable();
                cdavailable = false;
                finished = true;
            }

            if (finished == false)
            {
                cdavailable = true;
            }
        }
    }
}   