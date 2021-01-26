using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

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



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - 2f), new Vector2(1f, 0.5f), 180f, Vector2.down).collider.transform.tag);

        if (Input.GetAxis("Horizontal") != 0)
        {
            Move();
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
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !isTired)
        {
            transform.position += Input.GetAxis("Horizontal") * (transform.right * _sprintSpeed * Time.deltaTime);
            PlayerStats.DrainStamina(_staminaDrainRate * Time.deltaTime);
        }
        else
        {
            transform.position += Input.GetAxis("Horizontal") * (transform.right * _moveSpeed * Time.deltaTime);
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
    }

    private void Jump()
    {
        _rb.AddForce(new Vector2(0f, _jumpHeight));
        _cooldownTime = _jumpCooldown;
        _isJumping = true;
    }

    //private void OnDrawGizmos()
    //{
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y - 2f), new Vector3(1f, 0.5f, 0f));
    //}
}
