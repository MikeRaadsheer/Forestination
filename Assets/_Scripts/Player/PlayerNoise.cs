using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{

    private PlayerMove _movement;

    private static int _MovementNoise = 0;
    private static int _JumpNoise = 0;

    void Start()
    {
        _movement = GetComponent<PlayerMove>();

        _movement.MoveMode += SetMoveNoise;
        _movement.PlayerJumped += SetJumpNoise;
    }

    void SetMoveNoise(PlayerMoveMode _mode)
    {
        switch (_mode)
        {
            case PlayerMoveMode.IDLE:
                _MovementNoise = 0;
                break;
            case PlayerMoveMode.SNEAKING:
                _MovementNoise = 1;
                break;
            case PlayerMoveMode.WALKING:
                _MovementNoise = 3;
                break;
            case PlayerMoveMode.RUNNING:
                _MovementNoise = 5;
                break;
            default:
                break;
        }

        PlayerStats.Noise = _MovementNoise + _JumpNoise;
    }

    void SetJumpNoise()
    {
        StartCoroutine(JumpNoise());
    }

    private IEnumerator JumpNoise()
    {
        _JumpNoise = 3;
        PlayerStats.SetNoise(_MovementNoise + _JumpNoise);

        yield return new WaitForSeconds(0.5f);
        _JumpNoise = 0;
        PlayerStats.SetNoise(_MovementNoise + _JumpNoise);
    }

}
