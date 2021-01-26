using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{

    private PlayerMove _movement;

    public static int Noise = 0;

    private static int _MovementNoise = 0;
    private static int _JumpNoise = 0;

    void Start()
    {
        _movement = GetComponent<PlayerMove>();

        _movement.PlayerMoveMode += SetMoveNoise;
        _movement.PlayerJumped += SetJumpNoise;
    }

    void SetMoveNoise(MoveMode _mode)
    {
        switch (_mode)
        {
            case MoveMode.IDLE:
                _MovementNoise = 0;
                break;
            case MoveMode.SNEAKING:
                _MovementNoise = 2;
                break;
            case MoveMode.WALKING:
                _MovementNoise = 5;
                break;
            case MoveMode.RUNNING:
                _MovementNoise = 10;
                break;
            default:
                break;
        }

        Noise = _MovementNoise + _JumpNoise;
    }

    void SetJumpNoise()
    {
        StartCoroutine(JumpNoise());
    }

    private IEnumerator JumpNoise()
    {
        _JumpNoise = 5;
        Noise = _MovementNoise + _JumpNoise;

        yield return new WaitForSeconds(0.5f);
        _JumpNoise = 0;
        Noise = _MovementNoise + _JumpNoise;
    }

}
