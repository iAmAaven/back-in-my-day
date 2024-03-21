using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public int distanceToTravel = 360;
    public float distanceEverySec = 0.5f;

    public TextMeshProUGUI distanceText;

    private float timer = 0f;
    private JungleTutorial jungleTutorial;

    void Start()
    {
        jungleTutorial = FindObjectOfType<JungleTutorial>();
    }

    void Update()
    {
        if (jungleTutorial.isTutorialOn)
            return;

        if (Time.time >= timer)
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
