using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { SLEEP, WAKE, WALK, WORK, IDLE, DEAD }

public class Enemy : MonoBehaviour
{
    public GameObject sleepBalloon;
    public PoisionableObject poisonableObj;
    public AmountOfPoision requiredPoison = AmountOfPoision.NORMAL;
    public EnemyState _state = EnemyState.SLEEP;
    public Animator _anim;

    public int wakeUpNoiseLevel;
    public int instantWakeUpNoiseLevel;
    public float wakeUpNoiseTime;
    public float playerDectectionRange;

    protected float _distance;
    protected float _noiseTime = 0;
    protected Transform _target;
    protected Vector2 _pos;
    protected Vector2 _targetPos;


    private void Start()
    {
        _anim = GetComponent<Animator>();
        _pos = new Vector2(transform.position.x, transform.position.y);
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



    protected void CheckForPlayer()
    {
        if(_distance <= playerDectectionRange && PlayerStats.GetIsInsideTrailer())
        {
            PlayerStats.EndGame();
        }
    }

    public void WakeUp()
    {
        _state = EnemyState.WAKE;
        sleepBalloon.SetActive(false);
        _anim.SetTrigger("Wake");
    }

    public void ConsumeObj()
    {
        if (poisonableObj.isPoisoned)
        {
            int amount = 0;
            switch (poisonableObj.amountOfPoison)
            {
                case AmountOfPoision.LITTLE:
                    amount = 1;
                    break;
                case AmountOfPoision.NORMAL:
                    amount = 2;
                    break;
                case AmountOfPoision.LARGE:
                    amount = 3;
                    break;
                case AmountOfPoision.OVERKILL:
                    amount = 4;
                    break;
            }

            if (poisonableObj.amountOfPoison == requiredPoison || poisonableObj.amountOfPoison == requiredPoison + 1)
            {
                Die();
            }else if(poisonableObj.amountOfPoison > requiredPoison + 1)
            {
                PlayerStats.EndGame();
            }

        }
    }

    private void Die()
    {
        _anim.SetBool("isDead", true);
        _state = EnemyState.DEAD;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, playerDectectionRange);
    }

}
