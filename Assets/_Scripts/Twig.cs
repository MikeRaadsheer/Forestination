using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Twig : Interaction
{
    public Enemy targetEnemy;

    public override void Run()
    {
        targetEnemy.WakeUp();
        gameObject.SetActive(false);
    }
}
