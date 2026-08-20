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

    public void PlayMove(float horizontalInput)
    {
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput));
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool(IsGrounded, isGrounded);
    }

    public void SetVerticalVelocity(float verticalVelocity)
    {
        _animator.SetFloat(VerticalVelocity, verticalVelocity);
    }
}