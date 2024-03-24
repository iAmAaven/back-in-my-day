using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertedSettings : MonoBehaviour
{
    public Toggle invertedToggle;

    void Start()
    {
        if (PlayerPrefs.GetInt("InvertedControls") == 1)
        {
            invertedToggle.isOn = true;
        }
        else
        {
            invertedToggle.isOn = false;
            PlayerPrefs.SetInt("InvertedControls", 0);
        }
    }
    public void ToggleInvertedControls()
    {
        if (invertedToggle.isOn)
        {
            PlayerPrefs.SetInt("InvertedControls", 1);
        }
        else
        {
            PlayerPrefs.SetInt("InvertedControls", 0);
        }

        Debug.Log("Inverted controls: " + PlayerPrefs.GetInt("InvertedControls"));
    }
}
