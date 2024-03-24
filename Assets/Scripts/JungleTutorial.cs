using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleTutorial : MonoBehaviour
{
    public bool isTutorialOn = true;
    public GameObject tutorialCanvas;
    public bool startsIsPlaying = true;

    void Update()
    {
        if (isTutorialOn && Input.GetButtonDown("Fire1"))
        {
            if (startsIsPlaying)
            {
                FindObjectOfType<IsPlaying>().isGamePlaying = true;
            }
            tutorialCanvas.SetActive(false);
            Invoke("TutorialDisableOnTimer", 0.05f);
        }
    }
    void TutorialDisableOnTimer()
    {
        isTutorialOn = false;
    }
}
