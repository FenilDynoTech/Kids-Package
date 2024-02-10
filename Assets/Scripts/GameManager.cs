using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Text winTxt;

    public GameObject[] rockets;
    

    public Sprite[] fireRocket;

    public Transform genBoard;

    public List<GameObject> rocketsList;

    public float noTouchDuration = 2f; // Duration without touch input
    private float lastTouchTime;
    public float timer1;

    public bool isfired, rocketstop;

    public int randomNumber;
    public int count = 0;
    public int second1;

   

    private void Awake()
    {
        if (instance == null)   
        {
            instance = this;
        }
       InvokeRepeating("GenRocket",0f,0.5f) ;

        isfired = false;
        rocketstop = false;
        randomNumber = Random.Range(6, 21);
        
        /*
                for (int i = 1; i <= randomNumber; i++)
                {
                    int angle = Random.Range(-45, 45);
                    Vector3 position = genBoard.position + new Vector3(Random.Range(-9, 9f) + 0.2F, Random.Range(-1f, 3f), Random.Range(-2f, 2f));
                    int ran = Random.Range(0, rockets.Length);
                    Generate = Instantiate(rockets[ran], position, Quaternion.Euler(0, 0, angle), genBoard);
                    int temp = i;
                    rocketsList.Add(Generate);
                    //Generate.GetComponent<Button>().onClick.AddListener(() =>
                    //{
                    //    Generate.gameObject.GetComponent<Rocket>().OnclickRocket();
                    //}); 
                    Generate.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        Generate.GetComponent<Image>().sprite = fireRocket[ran];
                        Generate.gameObject.GetComponent<Rocket>().OnclickRocket();
                    });
                } */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rocket")
        {
            //count++;
            //print("Count =================  " + count);
            //collision.gameObject.transform.Translate(Vector2.zero);
            //rocketsList.Remove(collision.gameObject);
            //print("Total List Count ::::::::::::::: " + rocketsList.Count);

            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //if (count == randomNumber)
        //{
        //    print("Win ::::::::::::::::::");
        //    winTxt.SetActive(true);
        //    Time.timeScale = 0;
        //}
        //if(Input.GetMouseButtonDown(0))
        //{
        //    isfired = false;
        //    Reset();
        //}
        //else
        //{
        //    StartTime();
        //}

        //if(second1 == 10)
        //{
        //    isfired=true;
        //    Reset();
        //    InvokeRepeating("AutoFire",0f,2f);
        //}
    }

    //public void Reset()
    //{
    //    timer1 = 0;
    //    print("Time Reset");
    //}
    //public void StartTime()
    //{
    //    print("Time Start");

    //    timer1 += Time.deltaTime;
    //    second1 = Mathf.FloorToInt(timer1);
    //    print("Seconds ::: " + second1 + "s");
    //}

    public void AutoFire()
    {
        //if (isfired && rocketsList.Count > 0)
        //{
        //    int random = Random.Range(0, rocketsList.Count);
        //    await Task.Delay(2000);
        //    rocketsList[random].gameObject.GetComponent<Rocket>().isClick = true;
        //    rocketsList.Remove(rocketsList[random]);
        //}
        //else
        //{
        //    CancelInvoke("YourFunction");

        //}
    }

    public void GenRocket()
    {  
        int angle = Random.Range(-30, 30);
        Vector3 position = genBoard.position + new Vector3(Random.Range(-9, 9f), Random.Range(-1f, 3f), -1f);
        //float halfWidth = 500f; // Half of the width of the empty GameObject
        //Vector3 position = genBoard.position + new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-1f, 3f), Random.Range(-2f, 2f));
        int ran = Random.Range(0, rockets.Length);
        GameObject Generate = Instantiate(rockets[ran], position, Quaternion.Euler(0, 0, angle), genBoard);
        rocketsList.Add(Generate);
        Generate.GetComponent<Button>().onClick.AddListener(() =>{ Generate.GetComponent<Rocket>().OnclickRocket(); });


        //Generate.GetComponent<Button>().onClick.AddListener( () =>
        //{
        //    Generate.GetComponent<Image>().sprite = fireRocket[ran];
        //    Generate.gameObject.GetComponent<Rocket>().OnclickRocket();
        //});

    }

}

