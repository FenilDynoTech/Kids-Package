using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
   public static Rocket instance;

    Rigidbody2D rb;

    public float speed= 10f;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        rb = GetComponent<Rigidbody2D>();

       
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Go :::::::::::: ");
            rb.AddForce(transform.forward * speed);
        }
    }

}
