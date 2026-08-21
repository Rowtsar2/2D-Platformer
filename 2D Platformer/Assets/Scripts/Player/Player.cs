using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    private PlayerAnimator _playerAnimator;
    private PlayerJumper _playerJumper;
    private PlayerMover _playerMover;
    private InputReader _inputReader;

    private float _direction;
    private bool _isJump;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerMover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += OnMove;
        _inputReader.Jumped += OnJump;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= OnMove;
        _inputReader.Jumped -= OnJump;
    }

    private void Update()
    {
        _playerAnimator.SetGrounded(_groundChecker.IsGround);
        _playerAnimator.SetVerticalVelocity(_playerJumper.VerticalVelocity);
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_direction);

        if (_isJump && _groundChecker.IsGround)
        {
            _playerJumper.Jump();
        }
    }

    private void OnJump(bool isJumped)
    {
        _isJump = isJumped;
    }

    private void OnMove(float direction)
    {
        _playerAnimator.PlayMove(direction);
        _direction = direction;
    }
}