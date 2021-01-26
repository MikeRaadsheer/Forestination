using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public enum MoveMode { IDLE, SNEAKING, WALKING, RUNNING }

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private float _sneakSpeed = 2f;
    private float _moveSpeed = 5f;
    private float _sprintSpeed = 8f;
    private float _staminaDrainRate = 7.5f;
    private float _staminaRestoreRate = 15f;
    private bool isTired = false;

    private float _jumpHeight = 300f;
    private float _jumpCooldown = 1f;
    private float _cooldownTime;
    private bool _isJumping = false;

    private MoveMode _moveMode = MoveMode.IDLE;

    public Action<MoveMode> PlayerMoveMode;
    public Action PlayerJumped;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(PlayerNoise.Noise);


        if (Input.GetAxis("Horizontal") != 0)
        {
            Move();
        }
        else
        {
            _moveMode = MoveMode.IDLE;
            PlayerMoveMode?.Invoke(_moveMode);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            Jump();
        }


        if (_isJumping)
        {
            if (Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - 2f), new Vector2(1f, 0.5f), 180f, Vector2.down).collider.transform.tag == "Ground" && _cooldownTime <= 0)
            {
                _isJumping = false;
            }
        }
        
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += Input.GetAxis("Horizontal") * (transform.right * _sneakSpeed * Time.deltaTime);
            _moveMode = MoveMode.SNEAKING;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !isTired)
        {
            transform.position += Input.GetAxis("Horizontal") * (transform.right * _sprintSpeed * Time.deltaTime);
            PlayerStats.DrainStamina(_staminaDrainRate * Time.deltaTime);
            _moveMode = MoveMode.RUNNING;
        }
        else
        {
            transform.position += Input.GetAxis("Horizontal") * (transform.right * _moveSpeed * Time.deltaTime);
            _moveMode = MoveMode.WALKING;
        }

        if (isTired || !Input.GetKey(KeyCode.LeftShift))
        {
            PlayerStats.RestoreStamina(_staminaRestoreRate * Time.deltaTime);
        }

        if(PlayerStats.GetStamina() < 2.5f && !isTired)
        {
            isTired = true;
        }
        else if (PlayerStats.GetStamina() > 20f)
        {
            isTired = false;
        }

        PlayerMoveMode?.Invoke(_moveMode);
    }

    private void Jump()
    {
        _rb.AddForce(new Vector2(0f, _jumpHeight));
        _cooldownTime = _jumpCooldown;
        _isJumping = true;

        PlayerJumped?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, PlayerNoise.Noise);
    }
}
