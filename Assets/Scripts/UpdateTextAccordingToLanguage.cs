using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextAccordingToLanguage : MonoBehaviour
{
    [TextArea] public string finnishText, englishText;

    private TextMeshProUGUI textMesh;
    private LanguageHandler languageHandler;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        languageHandler = FindObjectOfType<LanguageHandler>();
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Language") != null)
        {
            switch (PlayerPrefs.GetString("Language"))
            {
                case "english":
                    languageHandler.UpdateTextToLanguage(textMesh, englishText);
                    break;
                case "finnish":
                    languageHandler.UpdateTextToLanguage(textMesh, finnishText);
                    break;
            }
        }
    }
}
