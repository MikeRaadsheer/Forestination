using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _rend;

    private void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");

        if (dir > 0)
        {
            _rend.flipX = false;
        }else if(dir < 0)
        {
            _rend.flipX = true;
        }
    }
}
