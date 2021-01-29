using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class TextBalloons : MonoBehaviour
{
    public string[] messages;

    public TextMeshPro _txt;
    private bool isTalking = true;

    private int currentMessage = 0;

    public Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(Talk());   
    }

    public void SeeBush()
    {
        isTalking = false;
        _anim.SetBool("isTalking", false);
    }

    private IEnumerator Talk()
    {
        while (isTalking)
        {
            _txt.text = messages[currentMessage];

            currentMessage++;

            if (currentMessage >= messages.Length)
            {
                currentMessage = 0;
            }
            yield return new WaitForSeconds(3f);
        }
    }

}
