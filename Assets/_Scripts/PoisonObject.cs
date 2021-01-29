using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoisonObject : MonoBehaviour
{

    public Action<AmountOfPoision> PoisonedAmount;

    public void Poison(int _poison)
    {
        switch (_poison)
        {
            case 0:
                PoisonedAmount?.Invoke(AmountOfPoision.NONE);
                break;
            case 1:
                PoisonedAmount?.Invoke(AmountOfPoision.LITTLE);
                break;
            case 2:
                PoisonedAmount?.Invoke(AmountOfPoision.NORMAL);
                break;
            case 3:
                PoisonedAmount?.Invoke(AmountOfPoision.LARGE);
                break;
            case 4:
                PoisonedAmount?.Invoke(AmountOfPoision.OVERKILL);
                break;
            default:
                break;
        }
        
    }

}
