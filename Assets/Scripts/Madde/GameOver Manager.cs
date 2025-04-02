using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Restart()
    {
        SceneManager.LoadScene(2);
    }

    void ExitProgram()
    {
        Application.Quit();
    }
}
