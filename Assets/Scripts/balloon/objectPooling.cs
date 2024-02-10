using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class objectPooling : MonoBehaviour
{

    public static objectPooling instance;

    public GameObject[] balloon;
    public GameObject parent;

    public int amountTotalBalloon;

    public List<GameObject> poolgameObject = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //InvokeRepeating("diableBalloon",0f,1.5f); 
    }
    void Start()
    {
        for (int i = 0; i < amountTotalBalloon; i++)
        {
            int angle = Random.Range(-30, 30);       
            Vector3 position = parent.transform.position + new Vector3(Random.Range(-5f , 5), Random.Range(-1f, 3f), -1);
            int random = Random.Range(1, balloon.Length);
            GameObject Generate = Instantiate(balloon[random], position, Quaternion.Euler(0, 0, angle), parent.transform);
            Generate.GetComponent<Button>().onClick.AddListener(() => { Generate.GetComponent<balloon>().OnclickBalloon(); });
            Generate.SetActive(false);
            poolgameObject.Add(Generate);
        }
    }


    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolgameObject.Count; i++)
        {
            if (!poolgameObject[i].activeInHierarchy)
            {
                return poolgameObject[i];
            }
        }
        return null;
    }

}

