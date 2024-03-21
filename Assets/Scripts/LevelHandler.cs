using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public string nextSceneName, gameOverSceneName;
    public GameObject fadeToBlack, fadeIn;

    void Start()
    {
        LevelStart();
    }
    void LevelStart()
    {
        fadeIn.SetActive(true);
        Destroy(fadeIn, 2f);
    }
    public void LevelEnd()
    {
        fadeToBlack.SetActive(true);
        Invoke("LoadNextScene", 4f);
    }

    public void LevelGameOver()
    {
        fadeToBlack.SetActive(true);
        Invoke("GameOverTimer", 4f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void GameOverTimer()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
