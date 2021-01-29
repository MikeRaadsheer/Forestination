using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    public GameObject menu;

    public void Disable()
    {
        menu.SetActive(false);
    }
}
