using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Interaction
{

    private AudioSource _thankPlayer;
    private bool _isPlaying = false;
    public GameObject particlesYay;

    private void Start()
    {
        particlesYay.SetActive(false);
    }

    public override void Run()
    {
        particlesYay.SetActive(true);
        if (_isPlaying)
        {
            _thankPlayer.Stop();
        }
        else
        {
            _thankPlayer.Play();
        }
    }

}
