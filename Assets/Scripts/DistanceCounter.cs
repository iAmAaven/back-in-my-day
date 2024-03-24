using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public int distanceToTravel = 300;
    public float distanceEverySec = 0.25f;
    [HideInInspector] public float startDistanceEverySec;

    public TextMeshProUGUI distanceText;

    private float timer = 0f;
    [HideInInspector] public bool isPlaying = false;

    void Start()
    {
        startDistanceEverySec = distanceEverySec;
    }

    void Update()
    {
        isPlaying = FindObjectOfType<IsPlaying>().isGamePlaying;
        if (Time.time >= timer && isPlaying)
        {
            TakeDistance();
            timer = Time.time + distanceEverySec;
        }
    }

    void TakeDistance()
    {
        if (distanceToTravel > 0)
        {
            distanceToTravel--;
            distanceText.text = "" + distanceToTravel + "km";
        }
        else
        {
            FindObjectOfType<LevelHandler>().LevelEnd();
        }
    }
}
