using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    public GameObject fadeToBlack;
    private bool isChanging = false;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isChanging == false)
        {
            isChanging = true;
            fadeToBlack.SetActive(true);
            Invoke("ChangeScene", 2f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
