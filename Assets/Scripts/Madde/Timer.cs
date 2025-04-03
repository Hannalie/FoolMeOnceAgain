using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;

    public float elapsedTime;
    private bool isRunning = true;

    

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int secounds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, secounds);
        }
        
    }

    public void LevelCompleted(int levelToLoad)
    {
        isRunning = false;
        PlayerPrefs.SetFloat("Level´Time", elapsedTime);
        PlayerPrefs.Save();
        SceneManager.LoadScene(levelToLoad);
    }

}
