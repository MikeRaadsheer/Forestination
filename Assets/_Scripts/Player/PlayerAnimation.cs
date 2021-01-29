using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _rend;
    private Animator _animator;

    private PlayerMove _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMove>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _movement.MoveMode += SetMoveMode;
    }

    private void Update()
    {
        float dir = Input.GetAxis("Horizontal");

        if (dir > 0)
        {
            _rend.flipX = false;
        }else if(dir < 0)
        {
            _rend.flipX = true;
        }
    }



    private void SetMoveMode(PlayerMoveMode _mode)
    {
        switch (_mode)
        {
            case PlayerMoveMode.IDLE:
                _animator.SetInteger("Movement", 0);
                break;
            case PlayerMoveMode.SNEAKING:
                _animator.SetInteger("Movement", 1);
                break;
            case PlayerMoveMode.WALKING:
                _animator.SetInteger("Movement", 1);
                break;
            case PlayerMoveMode.RUNNING:
                _animator.SetInteger("Movement", 1);
                break;
            default:
                break;
        }
    }
}
