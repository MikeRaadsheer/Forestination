using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoisionableObject : Interaction
{
    public GameObject UI;
    private bool _isPoisoning = false;
    public bool isPoisoned = false;
    public PoisonObject poison;
    public GameObject particle;

    [SerializeField]
    public AmountOfPoision amountOfPoison = AmountOfPoision.NONE;

    private void Start()
    {
        poison.PoisonedAmount += SetAmountOfPoision;
        UI.SetActive(false);
        particle.SetActive(false);
    }


    public override void Run()
    {
        if (isPoisoned)
        {
            Debug.Log("Object " + transform.name + " is already poisoned!");
            return;
        }
        _isPoisoning = true;
        UI.SetActive(true);
    }

    public void SetAmountOfPoision(AmountOfPoision _poison)
    {
        if (!_isPoisoning || _poison == AmountOfPoision.NONE)
        {
            _isPoisoning = false;
            UI.SetActive(false);
            return;
        }

        if (!PlayerStats.UsePoison(_poison))
        {
            return;
        }

        particle.SetActive(true);
        icon.SetActive(false);
        _isLocked = true;
        _isPoisoning = false;
        amountOfPoison = _poison;
        isPoisoned = true;
        UI.SetActive(false);
    }
}
