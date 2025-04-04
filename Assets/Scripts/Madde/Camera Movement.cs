using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;  // Referens till spelaren
    [SerializeField] private float smoothSpeed = 5f;  // Hur snabbt kameran fˆljer
    [SerializeField] private Vector3 offset = new Vector3(2f, 1f, -13f);  // Justera fˆr att fÅEr‰tt position

    void LateUpdate()
    {
        if (player != null)
        {
            // Ny kamera-position med en mjuk ˆvergÂng
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
