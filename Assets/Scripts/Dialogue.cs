using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public bool isLastDialogue = false;
    public GameObject nextDialogue;
    public GameObject fadeToBlack;
    public GameObject lastDialogueBox;
    public AudioSource transitionSound;
    public Animator zoomAnimator;
    public string nextSceneName;
    private bool isTransitioning = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isTransitioning == false)
        {
            isTransitioning = true;
            if (isLastDialogue)
            {
                FadeToBlack();
                if (lastDialogueBox != null)
                {
                    lastDialogueBox.SetActive(false);
                }
            }
            else
            {
                nextDialogue.SetActive(true);

                this.gameObject.SetActive(false);
            }
        }
    }

    void FadeToBlack()
    {
        if (transitionSound)
        {
            transitionSound.Play();
        }

        if (zoomAnimator != null)
        {
            zoomAnimator.SetTrigger("Zoom");
        }

        fadeToBlack.SetActive(true);

        Invoke("ChangeScene", 3f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
