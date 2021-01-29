using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI noise;
    public TextMeshProUGUI poison;
    public TextMeshProUGUI stamina;

    void Start()
    {
        PlayerStats.NoiseDel += SetNoiseTxt;
        PlayerStats.PoisonDel += SetPoisonTxt;
        PlayerStats.StaminaDel += SetStaminaTxt;
    }

    void SetStaminaTxt(float amount)
    {
        stamina.text = "Stamina: " + Math.Round(amount);
    }

    void SetPoisonTxt(int amount)
    {
        poison.text = "Poison: " + amount;
    }

    void SetNoiseTxt(int amount)
    {
        noise.text = "Noise: " + amount;
    }
}
