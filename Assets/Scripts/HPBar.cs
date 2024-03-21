using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public GameObject[] hearts;

    public void UpdateHPBar()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}
