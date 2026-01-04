using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    void Start()
    {
        if (PlayerPrefs.GetString("Language") != null)
        {
            switch (PlayerPrefs.GetString("Language"))
            {
                case "english":
                    dropdown.value = 0;
                    break;
                case "finnish":
                    dropdown.value = 1;
                    break;
            }
        }
    }
}
