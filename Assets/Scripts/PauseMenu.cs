using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
