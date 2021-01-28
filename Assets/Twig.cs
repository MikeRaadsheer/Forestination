using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Twig : Interaction
{
    public override void Run()
    {
        StartCoroutine(TwigNoise());
    }

    private IEnumerator TwigNoise()
    {
        int noise = 15;
        _isLocked = true;
        icon.SetActive(false);
        PlayerStats.Noise += noise;

        yield return new WaitForSeconds(0.1f);

        PlayerStats.Noise -= noise;
    }
}
