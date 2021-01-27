using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoisionableObject : Interaction
{
    public GameObject UI;
    private bool _isPoisoning = false;
    public PoisonObject poison;

    [SerializeField]
    private AmountOfPoision _amountOfPoison = AmountOfPoision.NONE;

    private void Start()
    {
        poison = FindObjectOfType<PoisonObject>();
        poison.PoisonedAmount += SetAmountOfPoision;
        UI.SetActive(false);
    }


    public override void Run()
    {
        _isPoisoning = true;
        UI.SetActive(true);
    }

    public void SetAmountOfPoision(AmountOfPoision _poison)
    {
        if (!_isPoisoning)
        {
            return;
        }

        _isPoisoning = false;
        _amountOfPoison = _poison;
        UI.SetActive(false);
    }
}
