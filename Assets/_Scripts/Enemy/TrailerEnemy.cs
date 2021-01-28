using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerEnemy : Enemy
{

    private void Update()
    {
        _targetPos = new Vector2(_target.position.x, _target.position.y);
        _distance = Vector2.Distance(_pos, _targetPos);

        Debug.Log(_distance);

        if (_state == EnemyState.SLEEP && _distance <= playerDectectionRange)
        {
            if (PlayerStats.Noise >= instantWakeUpNoiseLevel)
            {
                Debug.Log(PlayerStats.Noise + " | " + instantWakeUpNoiseLevel);
                WakeUp();
            }

            if (PlayerStats.Noise > wakeUpNoiseLevel)
            {
                _noiseTime += Time.deltaTime;
            }
            else if (_noiseTime != 0)
            {
                _noiseTime = 0;
            }
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
            case EnemyState.WALK:
                CheckForPlayer();
                break;
            case EnemyState.WORK:
                CheckForPlayer();
                break;
            case EnemyState.IDLE:
                CheckForPlayer();
                break;
        }
    }
}
