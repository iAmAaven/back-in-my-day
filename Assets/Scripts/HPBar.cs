using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public PlayerHP playerHP;
    public List<GameObject> hearts = new List<GameObject>();
    public GameObject blueHeart, pinkHeart;

    public void CreateHPBar(int maxHP)
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (i % 2 == 0)
            {
                hearts.Add(Instantiate(pinkHeart, transform));
            }
            else
            {
                hearts.Add(Instantiate(blueHeart, transform));
            }
        }
    }
    public void UpdateHPBar(int hp)
    {
        hearts[hp].SetActive(false);
    }
}
