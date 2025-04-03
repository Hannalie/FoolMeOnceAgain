using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private int levelToLoadWon;
    [SerializeField] private int levelToLoadLost;
    [SerializeField] private float timeLimit = 180;

    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("The time is: " + timer.elapsedTime);

            if (timer.elapsedTime > timeLimit)
            {
                timer.LevelCompleted(levelToLoadLost);
            }
            else
            {
                timer.LevelCompleted(levelToLoadWon);
            }
        }
    } */

}
