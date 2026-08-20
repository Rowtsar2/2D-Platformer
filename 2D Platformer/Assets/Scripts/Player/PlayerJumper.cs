using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100f;
    
    private Rigidbody2D _rigidbody2D;
    
    public float VerticalVelocity => _rigidbody2D.velocity.y;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(new Vector2( 0, _jumpForce));
    }
}
