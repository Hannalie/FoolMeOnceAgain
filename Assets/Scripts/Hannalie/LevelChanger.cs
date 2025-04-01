using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FadeOut", 0.5f);
        Invoke("LoadScene", 1.8f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
    private void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
