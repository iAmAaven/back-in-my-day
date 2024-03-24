using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeToBlack;
    public string sceneToLoad;
    public void StartGame()
    {
        if (fadeToBlack != null)
        {
            fadeToBlack.SetActive(true);
        }
        Invoke("ChangeScene", 2f);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToCredits()
    {
        if (fadeToBlack != null)
        {
            fadeToBlack.SetActive(true);
        }
        Invoke("ChangeToCredits", 2f);
    }
    void ChangeToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
