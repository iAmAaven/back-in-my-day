using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public string nextSceneName, gameOverSceneName;
    public float levelOverTimer = 2f;
    public bool levelHasBeenCompleted = false;
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
        levelHasBeenCompleted = true;
        fadeToBlack.SetActive(true);
        Invoke("LoadNextScene", levelOverTimer);
    }

    public void LevelGameOver()
    {
        fadeToBlack.SetActive(true);
        Invoke("GameOverTimer", levelOverTimer);
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
