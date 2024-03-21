using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleTutorial : MonoBehaviour
{
    public bool isTutorialOn = true;
    public GameObject tutorialCanvas;

    void Update()
    {
        if (isTutorialOn && Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<DistanceCounter>().isPlaying = true;
            tutorialCanvas.SetActive(false);
            isTutorialOn = false;
        }
    }
}
