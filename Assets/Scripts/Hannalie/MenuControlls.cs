using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour
{
    [SerializeField] private GameObject creditspanel;
    public Animator animator;
    public void StartGame()
    {
        animator.SetTrigger("FadeOut");
        Invoke("SceneChanger", 1.2f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditspanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditspanel.SetActive(false);
    }

    private void SceneChanger()
    {
        SceneManager.LoadScene(1);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
