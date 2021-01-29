using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject thisMenu;
    public GameObject otherMenu;

    public void SwitchMenu()
    {
        Debug.Log("LOADDDD!!!!!");
        otherMenu.SetActive(true);
        thisMenu.SetActive(false);
    }
}
