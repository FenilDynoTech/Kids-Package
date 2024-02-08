using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{


    Rigidbody2D rb;
    public Sprite fire;
    public float speed = 10f;

    public bool isClick = false;

    private void Awake()
    {

        isClick = false;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (isClick)
        {
            gameObject.transform.Translate(Vector2.up * 0.2f);
        }


    }
    public async void OnclickRocket()
    {

        print("Go :::::::::::: ");
        await Task.Delay(2000);
        isClick = true;

    }


}
