using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : MonoBehaviour
{

    public GameObject inside;
    public GameObject outside;
    public GameObject front;
    private bool isOutside = true;
    public BoxCollider2D[] insideWalls;

    private void Start()
    {
        for (int i = 0; i < insideWalls.Length; i++)
        {
            insideWalls[i].enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Please Enter");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOutside)
            {
                outside.SetActive(false);
                front.SetActive(false);

                for (int i = 0; i < insideWalls.Length; i++)
                {
                    insideWalls[i].enabled = true;
                }

                isOutside = false;
            }
            else
            {
                outside.SetActive(true);
                front.SetActive(true);

                for (int i = 0; i < insideWalls.Length; i++)
                {
                    insideWalls[i].enabled = false;
                }

                isOutside = true;
            }
        }
    }
}
