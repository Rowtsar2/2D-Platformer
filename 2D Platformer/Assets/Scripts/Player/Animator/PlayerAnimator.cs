using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Speed = PlayerAnimatorData.Params.Speed;
    private static readonly int IsGrounded = PlayerAnimatorData.Params.IsGrounded;
    private static readonly int VerticalVelocity = PlayerAnimatorData.Params.VerticalVelocity;

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