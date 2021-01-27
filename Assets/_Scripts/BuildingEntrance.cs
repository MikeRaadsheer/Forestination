using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntrance : Interaction
{

    public GameObject inside;
    public GameObject outside;
    public GameObject front;
    private bool isOutside = true;
    public BoxCollider2D[] insideWalls;

    private void Start()
    {
        icon.SetActive(false);
        for (int i = 0; i < insideWalls.Length; i++)
        {
            insideWalls[i].enabled = false;
        }
    }

    public override void Run()
    {
        if (isOutside)
        {
            outside.SetActive(false);
            front.SetActive(false);
            PlayerStats.SetIsInsideTrailer(true);
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
            PlayerStats.SetIsInsideTrailer(false);
            for (int i = 0; i < insideWalls.Length; i++)
            {
                insideWalls[i].enabled = false;
            }

            isOutside = true;
        }
    }
}
