using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private const string IsGrounded = nameof(IsGrounded);
    private const string VerticalVelocity = nameof(VerticalVelocity);
    
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimator(float horizontalInput, bool isGrounded, float verticalVelocity)
    {
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput));
        _animator.SetBool(IsGrounded, isGrounded);
        _animator.SetFloat(VerticalVelocity, verticalVelocity);
    }
}
