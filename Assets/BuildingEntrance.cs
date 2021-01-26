using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : MonoBehaviour
{

    public GameObject outside;
    public GameObject inside;
    private bool isOutside = true;

    private void Start()
    {
        outside.SetActive(true);
        inside.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOutside)
            {
                outside.SetActive(false);
                inside.SetActive(true);
                isOutside = false;
            }
            else
            {
                outside.SetActive(true);
                inside.SetActive(false);
                isOutside = true;
            }
        }
    }
}
