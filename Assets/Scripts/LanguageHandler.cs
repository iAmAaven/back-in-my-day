using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageHandler : MonoBehaviour
{
    public void HandleInputData(int val)
    {
        switch (val)
        {
            case 0:
                PlayerPrefs.SetString("Language", "english");
                break;
            case 1:
                PlayerPrefs.SetString("Language", "finnish");
                break;
        }

        Debug.Log(PlayerPrefs.GetString("Language"));
    }
    public void UpdateTextToLanguage(TextMeshProUGUI textMesh, string languageText)
    {
        textMesh.text = languageText;
    }
}
