using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public void SelectDifficulty(string chosenDifficulty)
    {
        PlayerPrefs.SetString("Difficulty", chosenDifficulty);
    }
}
