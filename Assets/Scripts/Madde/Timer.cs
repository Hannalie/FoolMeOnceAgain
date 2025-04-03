using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    public float elapsedTime;

    

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int secounds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, secounds);
    }
}
