using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("LevelTime", 0f);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int secounds = Mathf.FloorToInt(elapsedTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, secounds);
    }
}
