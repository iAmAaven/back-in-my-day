using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    [TextArea] public string[] uIText;
    public char[] endChars;
    public char[] pauseChars;

    [Header("Typing speed")]
    public float timeBetweenChars;
    public float pauseAfterEndChar;
    public float pauseAfterPauseChar;
    [Header("Automatic")]
    public bool willClose;
    public float closeAfter;
    public bool typeAll = false;

    // PRIVATES
    private TextMeshProUGUI textMesh;
    private string processedText;
    private int currentText = 0;
    private bool isTyping = false;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        if (typeAll == true)
        {
            StartCoroutine(TypeAllTexts());
            return;
        }
        TypeNextDialogue();
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        processedText = null;

        for (int i = 0; i < uIText[currentText].Length; i++)
        {
            processedText += uIText[currentText][i];
            textMesh.text = processedText;
            yield return new WaitForSeconds(timeBetweenChars);

            if (endChars.Contains(uIText[currentText][i]))
            {
                yield return new WaitForSeconds(pauseAfterEndChar);
            }
            else if (pauseChars.Contains(uIText[currentText][i]))
            {
                yield return new WaitForSeconds(pauseAfterPauseChar);
            }
        }

        if (willClose)
        {
            yield return new WaitForSeconds(closeAfter);
            gameObject.SetActive(false);
        }

        isTyping = false;
        currentText++;
        if (currentText >= uIText.Length)
        {
            currentText = 0;
        }
    }
    IEnumerator TypeAllTexts()
    {
        isTyping = true;
        processedText = null;
        for (int newText = 0; newText < uIText.Length; newText++)
        {
            for (int i = 0; i < uIText[currentText].Length; i++)
            {
                processedText += uIText[currentText][i];
                textMesh.text = processedText;
                yield return new WaitForSeconds(timeBetweenChars);

                if (endChars.Contains(uIText[currentText][i]))
                {
                    yield return new WaitForSeconds(pauseAfterEndChar);
                }
                else if (pauseChars.Contains(uIText[currentText][i]))
                {
                    yield return new WaitForSeconds(pauseAfterPauseChar);
                }
            }
            currentText++;
        }

        if (willClose)
        {
            yield return new WaitForSeconds(closeAfter);
            gameObject.SetActive(false);
        }

        isTyping = false;
    }

    public void TypeNextDialogue()
    {
        if (isTyping == false)
        {
            StartCoroutine(TypeText());
        }
    }
}
