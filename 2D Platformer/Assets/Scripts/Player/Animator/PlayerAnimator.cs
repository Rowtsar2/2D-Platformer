using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void PlayMove(float horizontalInput)
    {
        _animator.SetFloat(PlayerAnimatorParams.Speed, Mathf.Abs(horizontalInput));
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool(PlayerAnimatorParams.IsGrounded, isGrounded);
    }

    public void SetVerticalVelocity(float verticalVelocity)
    {
        _animator.SetFloat(PlayerAnimatorParams.VerticalVelocity, verticalVelocity);
    }
}