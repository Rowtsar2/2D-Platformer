using UnityEngine;

public static class PlayerAnimatorParams
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    public static readonly int VerticalVelocity = Animator.StringToHash(nameof(VerticalVelocity));
}