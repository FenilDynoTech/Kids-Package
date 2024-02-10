
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Rocket : MonoBehaviour
{


    Rigidbody2D rb;
    public Sprite fire;
    public float speed = 10f;

    public static bool isClick = false;

    List<int> tempList = new List<int>();

    public GameObject blastAnimation;

    private void Awake()
    {

        isClick = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void Update()
    {
        gameObject.transform.Translate(Vector2.up * 0.05f);
        //if (isClick)
        //{
        //    gameObject.transform.Translate(Vector2.up * 0.1f);
        //}


    }
    public  void OnclickRocket()
    {
        GameManager.instance.rocketsList.Remove(gameObject);
        //gameObject.SetActive(false);
        Destroy(gameObject);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject Generate = Instantiate(blastAnimation, mousePosition, Quaternion.identity);
        Generate.GetComponent<ParticleSystem>().Play();
       //GameObject Generate = Instantiate(blastAnimation, mousePosition, Quaternion.identity,GameManager.instance.genBoard);

       // Destroy(Generate,0.5f);
        GameManager.instance.count++;
        print("count:::::::::::: " + GameManager.instance.count);
        
        /* print("Go :::::::::::: ");
        await Task.Delay(2000);
        isClick = true; */
    }

}
