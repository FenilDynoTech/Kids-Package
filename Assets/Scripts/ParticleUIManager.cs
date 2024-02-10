using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleUIManager : MonoBehaviour
{


    [SerializeField] GameObject[] fireworks;
    [SerializeField] GameObject fireworksHolder;
    public GameObject prefabToInstantiate;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    private Coroutine destroyCoroutine;




    void Update()
    {
        int random = Random.Range(0, fireworks.Length);

        if (Input.GetMouseButtonDown(0))
        {
            // Single click - Instantiate a prefab and destroy it after 1.5 seconds
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject Generate = Instantiate(fireworks[random], mousePosition, Quaternion.identity);
            Generate.transform.SetParent(fireworksHolder.transform);
            Generate.transform.position = new Vector3(mousePosition.x, mousePosition.y, -506f);
            StartCoroutine(DestroyAfterDelay(Generate, 1.5f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Start of drag - Initialize drag parameters
            isDragging = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            // Dragging - Instantiate prefabs along the drag path
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dragDirection = currentMousePosition - lastMousePosition;
            float dragDistance = dragDirection.magnitude;

            // Define the desired quantity of prefabs to instantiate
            float desiredQuantity = 1f; // Change this as needed

            // Calculate the step size based on the total distance and desired quantity
            float stepSize = dragDistance / desiredQuantity;

            // Instantiate prefabs along the path at intervals determined by the step size
            for (float distance = 0; distance < dragDistance; distance += stepSize)
            {
                Vector3 spawnPosition = lastMousePosition + dragDirection.normalized * distance;
                GameObject Generate = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                Generate.transform.SetParent(fireworksHolder.transform);
                Generate.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, -506f);
                destroyCoroutine = StartCoroutine(DestroyAfterDelay(Generate, 1.5f));
            }

            lastMousePosition = currentMousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // End of drag - Stop dragging and destroy the prefabs after 1.5 seconds
            isDragging = false;
        }
    }

    IEnumerator DestroyAfterDelay(GameObject prefab, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(prefab);
    }

}

