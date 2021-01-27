using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { SLEEP, WAKE, WALK, WORK, IDLE, DEAD }

public class Enemy : MonoBehaviour
{
    public GameObject sleepBalloon;
    private EnemyState _state = EnemyState.SLEEP;
    private Animator _anim;

    public int wakeUpNoiseLevel = 2;
    public float wakeUpNoiseTime = 1.5f;
    public float playerDectectionRange;

    private float _distance;
    private float _noiseTime = 0;
    private Transform _target;
    private Vector2 _pos;
    private Vector2 _targetPos;


    private void Start()
    {
        _anim = GetComponent<Animator>();
        _pos = new Vector2(transform.position.x, transform.position.y);
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        _targetPos = new Vector2(_target.position.x, _target.position.y);
        _distance = Vector2.Distance(_pos, _targetPos);

        if (PlayerNoise.Noise > wakeUpNoiseLevel && _state == EnemyState.SLEEP && _distance <= playerDectectionRange)
        {
            _noiseTime += Time.deltaTime;
        }
        else if (_noiseTime != 0)
        {
            _noiseTime = 0;
        }

        if (_noiseTime >= wakeUpNoiseTime && _state != EnemyState.WAKE)
        {
            WakeUp();
        }

        switch (_state)
        {
            case EnemyState.WAKE:
                CheckForPlayer();
                break;
            //case EnemyState.WALK:
            //case EnemyState.WALK:
            //    break;
            //case EnemyState.WORK:
            //    break;
            //case EnemyState.IDLE:
            //    break;
            //case EnemyState.DEAD:
            //    break;
        }

    }

    private void CheckForPlayer()
    {
        if(_distance <= playerDectectionRange && PlayerStats.GetIsInsideTrailer())
        {
            PlayerStats.EndGame();
        }
    }

    private void WakeUp()
    {
        _state = EnemyState.WAKE;
        sleepBalloon.SetActive(false);
        _anim.SetTrigger("Wake");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, playerDectectionRange);
    }

}
