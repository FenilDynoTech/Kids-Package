using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BalloonManager : MonoBehaviour
{

    public static BalloonManager instance;


    public Transform parent;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InvokeRepeating("GenBallon", 0f, 0.5f);

    }


    public void GenBallon()
    {
        /* int angle = Random.Range(-30, 30);
         int ran = Random.Range(0, rockets.Length);
         GameObject Generate = Instantiate(rockets[ran], position, Quaternion.Euler(0, 0, angle), genBoard);
         rocketsList.Add(Generate);
         Generate.GetComponent<Button>().onClick.AddListener(() =>{ Generate.GetComponent<Rocket>().OnclickRocket(); }); */

        Vector3 position = parent.position + new Vector3(Random.Range(-5f,5f), Random.Range(-1f, 3f), -1f);
        GameObject balloon = objectPooling.instance.GetPoolObject();

        if (balloon != null)
        {
            balloon.transform.position = position;
            balloon.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "balloon")
        {
            collision.gameObject.SetActive(false);
        }
    }



}

