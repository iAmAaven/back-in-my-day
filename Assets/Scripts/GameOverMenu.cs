using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string previousSceneName;

    public void TryAgain()
    {
        SceneManager.LoadScene(previousSceneName);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
