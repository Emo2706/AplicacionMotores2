using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public static SceneManagment instance;
    private void Awake()
    {

        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        if (index == 1)
        {

        }
    }



    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
