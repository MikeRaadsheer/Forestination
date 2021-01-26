using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform target;
    private Vector2 _boundaries = new Vector2(4f, 2f);

    private Vector3 _lastPos;
    private float _idleTime = 0f;
    private float _timeToCenter = 5f;
    private bool _isCentering = false;

    private void Start()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        float z = transform.position.z;

        Vector3 targetPos = new Vector3(targetX, targetY, z);

        transform.position = targetPos;
    }

    void Update()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        Vector3 targetPos = new Vector3(targetX, targetY, z);
        Vector3 pos = new Vector3(x, y, z);

        float differenceX = x - targetX;
        float differenceY = y - targetY;

        if (math.abs(differenceX) > _boundaries.x || math.abs(differenceY) > _boundaries.y)
        {
            if(differenceX > 20)
            {
                transform.position = targetPos;
            }
            else if(differenceX > 10)
            {
                Follow(pos, targetPos, 1);
            }
            else
            {
                Follow(pos, targetPos, 0.01f);
            }
        }

        if (pos == _lastPos)
        {
            _idleTime += Time.deltaTime;
            if (_idleTime >= _timeToCenter)
            {
                _isCentering = true;
            }
        }
        else
        {
            _lastPos = pos;
            _idleTime = 0;
        }
        
        if(_isCentering && !Input.anyKey)
        {
            Follow(pos, targetPos, 0.0025f);
        }
        else
        {
            _isCentering = false;
        }

    }

    private void Follow(Vector3 _pos, Vector3 _targetPos, float _speed)
    {
        transform.position = Vector3.Lerp(_pos, _targetPos, _speed);
    }
}
