using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public Transform target;
    [SerializeField]
    private Vector2 _boundaries;
    [SerializeField]
    private float _followSpeed;

    private Vector3 lastPos;
    private float idleTime = 0f;
    private float timeToCenter = 5f;
    private bool isCentering = false;

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
                Follow(pos, targetPos, 0);
            }
            else
            {
                Follow(pos, targetPos, 100);
            }
        }

        if (pos == lastPos)
        {
            idleTime += Time.deltaTime;
            if (idleTime >= timeToCenter)
            {
                isCentering = true;
            }
        }
        else
        {
            lastPos = pos;
            idleTime = 0;
        }
        
        if(isCentering && !Input.anyKey)
        {
            Follow(pos, targetPos, 500);
        }
        else
        {
            isCentering = false;
        }

    }

    private void Follow(Vector3 _pos, Vector3 _targetPos, int drag)
    {
        transform.position = Vector3.Lerp(_pos, _targetPos, _followSpeed / drag);
    }
}
