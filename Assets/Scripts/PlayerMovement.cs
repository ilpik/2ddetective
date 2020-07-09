using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool _makeFlip;

    private SpriteRenderer _playerSr;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRb;

    [SerializeField] private float _horizontalAxis;
    [SerializeField] private float _speed;
    private bool _run;
    private bool _aim;
    private bool _crouch;
    private bool _shoot;
    private bool _reload;
    private bool _gunout;

    void Start()
    {
        _playerSr = GetComponentInChildren<SpriteRenderer>();
        _playerAnimator = GetComponentInChildren<Animator>();
        _playerRb = GetComponentInChildren<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Run();
        Aim();
        Crouch();
        Shoot();
        Reload();
        GunOut();
    }

    void Run()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _run = (_horizontalAxis != 0);
        if (_run)
        {
            //transform.Translate(new Vector3(_speed * _horizontalAxis * Time.deltaTime, 0, 0), Space.World);
            _playerRb.velocity = new Vector2(_speed * _horizontalAxis, _playerRb.velocity.y);
        }
        _playerAnimator.SetBool("run", _run);
        FlipSprite(_horizontalAxis);

    }

    void FlipSprite(float horizontalAxis)
    {
        if (horizontalAxis < 0)
        {
            _makeFlip = true;
        }
        else if (horizontalAxis > 0)
        {
            _makeFlip = false;
        }
        _playerSr.flipX = _makeFlip;
    }
    void Aim()
    {
        _aim = Input.GetKey("q");
        _playerAnimator.SetBool("aim", _aim);
    }

    void Crouch()
    {
        _crouch = Input.GetAxis("Vertical")<0;
        _playerAnimator.SetBool("crouch", _crouch);
    }

    void Shoot()
    {
        _shoot = Input.GetKey("w");
        _playerAnimator.SetBool("shoot",_shoot);
    }

    void Reload()
    {
        _reload = Input.GetKeyUp("r");
        _playerAnimator.SetBool("reload", _reload);
    }

    void GunOut()
    {
        _gunout = Input.GetKey("e");
        _playerAnimator.SetBool("gunout", _gunout);
    }

 
    //private void Jump()
    //{
    //    isGrouded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

    //    if (Input.GetKey("space") && isGrouded == true)
    //    {
    //        playerRb.velocity = new Vector2(0, speed);
    //        playerAnim.Play("PlayerJump");
    //        i++;
    //        Debug.Log(i);
    //    }
    //}
}
