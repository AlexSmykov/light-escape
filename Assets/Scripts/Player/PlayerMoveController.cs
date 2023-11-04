using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float dashCooldown;
    [SerializeField] private float speed;
    
    private Vector2 _inputMoveNormalized;
    private PlayerController _player;
    private Animator _animator;
    private float _currentDashCooldown;
    private Rigidbody2D _playerRigidbody2D;
    private bool _canMove;
    public bool canMove
    {
        get => _canMove;
        set
        {
            _canMove = value;
            _playerRigidbody2D.constraints = value ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.FreezeAll;
        }
    }
    
    [HideInInspector] public Transform playerTransform;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _canMove = true;
        playerTransform = transform;
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _currentDashCooldown = dashCooldown;
        _player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!_canMove) return;
        var inputMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _inputMoveNormalized = inputMove.normalized;
        var velocity = _playerRigidbody2D.velocity;
        var inputMoveResult = inputMove * speed - velocity * 2f;


        if (inputMove.x != 0 || inputMove.y != 0)
        {
            _player.isRunning = true;
        }
        else
        {
            _player.isRunning = false;
        }
        
        _playerRigidbody2D.AddForce(inputMoveResult, ForceMode2D.Force);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var position = transform.position;
        var pos = new Vector2(position.x, position.y);
        Gizmos.DrawLine(pos, pos + _inputMoveNormalized);
        
        if (_playerRigidbody2D)
        {
            Gizmos.DrawLine(pos, pos + _playerRigidbody2D.velocity.normalized);
        }
    }
#endif

    private void MovePlayer()
    {
        
    }

    private void Dash()
    {
        
    }
}
