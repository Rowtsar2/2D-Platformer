using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovment : MonoBehaviour
{
    [Header("Move value")]
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _jumpForce = 14f;
    
    [Header("Ground check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.10f;
    [SerializeField] private LayerMask _groundLayer;


    private PlayerAnimator _playerAnimator;
    private Rigidbody2D _rigidbody2D;
    
    private float _horizontalInput;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (_horizontalInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(_horizontalInput), 1, 1);
        
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
        
        _playerAnimator.UpdateAnimator(_horizontalInput, _isGrounded, _rigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
    }


    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}

