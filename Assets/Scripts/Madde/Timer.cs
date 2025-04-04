using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float elapsedTime = 0f;
    private bool isRunning = true;

    private void Start()
    {
        // Reset timer if in Scene 3
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            elapsedTime = 0f;  // Reset timer when scene 3 starts
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // In Scene 4, retrieve and display the final time
            elapsedTime = PlayerPrefs.GetFloat("timeValue", 0f);
            isRunning = false;  // Stop timer in Scene 4
        }

        UpdateTimerUI();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelCompleted(3);
        }
    }

    public void LevelCompleted(int levelToLoad)
    {
        PlayerPrefs.SetFloat("timeValue", elapsedTime); // Save final time
        PlayerPrefs.Save();
        isRunning = false;

        Invoke("LevelThing", 0.6f);
    }

    private void LevelThing()
    {
        SceneManager.LoadScene(3);
    }
}
