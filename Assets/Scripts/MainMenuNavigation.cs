using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuNavigation : MonoBehaviour
{
    public GameObject[] menuList;
    public Button[] firstButtonInMenu;
    // public Button[] buttonsInMenu;
    public int menuID = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            firstButtonInMenu[menuID].Select();
        }
    }

    public void ActivateNextMenu(int id)
    {
        menuID = id;
        Debug.Log("Menu id: " + menuID);
        Invoke("SelectFirstButton", 0.1f);
    }

    void SelectFirstButton()
    {
        firstButtonInMenu[menuID].Select();
    }
}
