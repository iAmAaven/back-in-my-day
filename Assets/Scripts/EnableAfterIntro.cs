using UnityEngine;
using System.Collections;

public class EnableAfterIntro : MonoBehaviour
{
    public GameObject generators;
    public bool isPlaying = false;

    void Update()
    {
        if (isPlaying == true)
        {
            generators.SetActive(true);
        }
    }
}
