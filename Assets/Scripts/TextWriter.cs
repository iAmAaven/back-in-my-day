using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    [TextArea] public string finnishText;
    [TextArea] public string englishText;
    public char[] endChars;
    public char[] pauseChars;

    [Header("Typing speed")]
    public float timeBetweenChars;
    public float pauseAfterEndChar;
    public float pauseAfterPauseChar;
    [Header("Automatic dialogue closing")]
    public bool willClose;
    public float closeAfter;

    // PRIVATES
    private TextMeshProUGUI textMesh;
    private string processedText;
    [HideInInspector] public string uIText;
    private LanguageHandler languageHandler;

    void Start()
    {
        if (PlayerPrefs.GetString("Language") != null)
        {
            UpdateLanguageToText();
        }
        else
        {
            uIText = finnishText;
        }

        languageHandler = FindObjectOfType<LanguageHandler>();
        textMesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeText());
    }

    public IEnumerator TypeText()
    {
        for (int i = 0; i < uIText.Length; i++)
        {
            processedText += uIText[i];
            textMesh.text = processedText;
            yield return new WaitForSeconds(timeBetweenChars);

            if (endChars.Contains(uIText[i]))
            {
                yield return new WaitForSeconds(pauseAfterEndChar);
            }
            else if (pauseChars.Contains(uIText[i]))
            {
                yield return new WaitForSeconds(pauseAfterPauseChar);
            }
        }

        if (willClose)
        {
            yield return new WaitForSeconds(closeAfter);
            gameObject.SetActive(false);
        }
    }

    public void UpdateLanguageToText()
    {
        if (PlayerPrefs.GetString("Language") != null)
        {
            switch (PlayerPrefs.GetString("Language"))
            {
                case "finnish":
                    uIText = finnishText;
                    break;

                case "english":
                    uIText = englishText;
                    break;
            }
        }
    }
}
