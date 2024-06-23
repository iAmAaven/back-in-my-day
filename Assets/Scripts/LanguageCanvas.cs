using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageCanvas : MonoBehaviour
{
    public GameObject mainMenuCanvas, languageCanvas;
    public GameObject playButton, languageButton;
    public EventSystem eventSystem;
    void Start()
    {
        if (PlayerPrefs.GetString("Language") == "english" || PlayerPrefs.GetString("Language") == "finnish")
        {
            mainMenuCanvas.SetActive(true);
            languageCanvas.SetActive(false);
            eventSystem.firstSelectedGameObject = playButton;
        }
        else
        {
            languageCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
            eventSystem.firstSelectedGameObject = languageButton;
        }

        Debug.Log(PlayerPrefs.GetString("Language"));
    }

    void Update()
    {
        if (languageCanvas.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            languageButton.GetComponent<Button>().Select();
        }
    }

    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
    }
}
