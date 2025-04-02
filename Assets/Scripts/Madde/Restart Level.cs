using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public Transform spawnPosition;
    private CameraMovement cameraMovement;

    private void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();

        if (cameraMovement == null)
        {
            Debug.LogError("CameraMovement script not found on Main Camera!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPosition.position;
            Debug.Log("Changing scene");

            if (cameraMovement != null)
            {
                //cameraMovement.InstantFollow(); // Flytta kameran direkt efter teleportering
                Debug.Log("Camera moved to new position");
            }
        }
    }
}
