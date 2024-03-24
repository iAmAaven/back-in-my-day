using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject nextDialogue;
    public bool isLastDialogue = false;
    public GameObject fadeToBlack;
    public AudioSource transitionSound;
    public string nextSceneName;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isLastDialogue)
            {
                FadeToBlack();
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
        fadeToBlack.SetActive(true);

        Invoke("ChangeScene", 3f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
