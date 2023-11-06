using UnityEngine;


[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerResourcesController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float dashCooldown;
    [SerializeField] private float speed;
    
    private Vector2 _inputMoveNormalized;
    private PlayerController _player;
    private PlayerResourcesController _playerResources;
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
        _animator = GetComponent<Animator>();
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _currentDashCooldown = dashCooldown;
        _player = GetComponent<PlayerController>();
        _playerResources = GetComponent<PlayerResourcesController>();
    }

    private void Update()
    {
        if (!_canMove) return;
        var inputMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _inputMoveNormalized = inputMove.normalized;
        var velocity = _playerRigidbody2D.velocity;
        var bootsSpeed = 0f;
        if (_playerResources.boots)
        {
            bootsSpeed =  (float)_playerResources.boots.effect / 100;
        }

        var mults = _player.playerTerrainSpeed * (_player.playerSpeedMove + bootsSpeed);
        var inputMoveResult = inputMove * speed * mults - velocity * 2 * (_player.playerSpeedMove + bootsSpeed);

        if (inputMove.x != 0 || inputMove.y != 0)
        {
            _player.isRunning = true;
            _animator.SetBool("isRunning", true);
            _animator.Play("playerRun");

            if (inputMove.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (inputMove.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            _player.isRunning = false;
            _animator.SetBool("isRunning", false);
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
