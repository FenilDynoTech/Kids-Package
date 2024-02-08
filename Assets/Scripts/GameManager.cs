using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject[] rockets;

    public Transform genBoard;

    public List<GameObject> rocketsList;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

         

        for (int i = 0; i < rockets.Length; i++)
        {
   
            int angle = Random.Range(-45, 45);
            Vector3 position = genBoard.position + new Vector3(Random.Range(-9, 9f)+0.2F, Random.Range(-1f, 3f), Random.Range(-2f, 2f));
            GameObject g = Instantiate(rockets[i], position, Quaternion.Euler(0, 0, angle), genBoard);
            rocketsList.Add(g);
        }   
}

    








}
