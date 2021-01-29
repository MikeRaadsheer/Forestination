using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBush : Interaction
{
    public TextBalloons jack;
    public PoisionableObject bush;

    public override void Run()
    {
        if (bush.isPoisoned)
        {
            jack.SeeBush();
            _isLocked = true;
        }
    }
}
