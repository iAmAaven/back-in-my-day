using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public float musicChangeDuration = 2f;
    public float targetVolume;
    void Start()
    {
        StartCoroutine(SmoothVolumeChange());
    }

    private IEnumerator SmoothVolumeChange()
    {
        float currentVolume;
        float timer = 0f;

        while (timer < musicChangeDuration)
        {
            timer += Time.deltaTime;
            currentVolume = Mathf.Lerp(0f, targetVolume, timer / musicChangeDuration);
            musicSource.volume = currentVolume;
            yield return null; // Wait for the next frame
        }

        // Ensure we reach the target intensity exactly
        musicSource.volume = targetVolume;
    }
}
