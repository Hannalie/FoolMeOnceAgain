using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;  // Referens till spelaren
    [SerializeField] private float smoothSpeed = 5f;  // Hur snabbt kameran följer
    [SerializeField] private Vector3 offset = new Vector3(2f, 1f, -10f);  // Justera för att få rätt position

    void LateUpdate()
    {
        if (player != null)
        {
            // Ny kamera-position med en mjuk övergång
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
