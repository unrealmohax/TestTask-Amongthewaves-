using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsGrounded = "IsGrounded";
    private const string IsJumping = "IsJumping";
    private const string IsFalling = "IsFalling";
    private const string IsJumpingOnPlace = "IsJumpingOnPlace";
    private const string IsFallingOnPlace = "IsFallingOnPlace";
    private const string IsAirborne = "IsAirborne";
    private const string IsMovement = "IsMovement";
    private const string IsNoControlMovement = "IsNoControlMovement";
    private const string IsPushing = "IsPushing";
    private const string IsWall = "IsWall";
    private const string IsSlideOnWall = "IsSlideOnWall";
    private const string IsRunningTurn = "IsRunningTurn";
    private const string IsTackle = "IsTackle";
    private const string IsHardLanding = "IsHardLanding";
    private const string IsDash = "IsDash";
    private const string IsDying = "IsDying";

    private const string PushingMass = "PushingMass";
    private const string MovementVelocity = "MovementVelocity";

    private Animator _animator;

    public readonly UnityEvent onAnimFinished = new UnityEvent();
    public readonly UnityEvent onJumpEvent = new UnityEvent();
    
    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartGrounded() => _animator.SetBool(IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(IsGrounded, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StartJumpingOnPlace() => _animator.SetBool(IsJumpingOnPlace, true);
    public void StopJumping()
    {
        _animator.SetBool(IsJumping, false);
        _animator.SetBool(IsJumpingOnPlace, false);
    }

    public void StartFalling() => _animator.SetBool(IsFalling, true);
    public void StartFallingOnPlace() => _animator.SetBool(IsFallingOnPlace, true);
    public void StopFalling() 
    {
        _animator.SetBool(IsFalling, false);
        _animator.SetBool(IsFallingOnPlace, false);
    }

    public void StartAirborne() => _animator.SetBool(IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(IsAirborne, false);

    public void StartMovement() => _animator.SetBool(IsMovement, true);
    public void StopMovement() => _animator.SetBool(IsMovement, false);

    public void StartNoControlMovement() => _animator.SetBool(IsNoControlMovement, true);
    public void StopNoControlMovement() => _animator.SetBool(IsNoControlMovement, false);

    public void StartWallContact() => _animator.SetBool(IsWall, true);
    public void StopWallContact() => _animator.SetBool(IsWall, false);

    public void StartSlideOnWall() => _animator.SetBool(IsSlideOnWall, true);
    public void StopSlideOnWall() => _animator.SetBool(IsSlideOnWall, false);

    public void StartRunningTurn() => _animator.SetBool(IsRunningTurn, true);
    public void StopRunningTurn() => _animator.SetBool(IsRunningTurn, false);

    public void StartTackle() => _animator.SetBool(IsTackle, true);
    public void StopTackle() => _animator.SetBool(IsTackle, false);

    public void StartHardLanding() => _animator.SetBool(IsHardLanding, true);
    public void StopHardLanding() => _animator.SetBool(IsHardLanding, false);

    public void StartDash() => _animator.SetBool(IsDash, true);
    public void StopDash() => _animator.SetBool(IsDash, false);

    public void StartDying() => _animator.SetBool(IsDying, true);
    public void StopDying() => _animator.SetBool(IsDying, false);

    public void StartPushing(float mass)
    {
        _animator.SetBool(IsPushing, true);
        _animator.SetFloat(PushingMass, mass);
    }

    public void SetMovementVelocity(float velocity)
    {
        _animator.SetFloat(MovementVelocity, velocity);
    }

    public void StopPushing() => _animator.SetBool(IsPushing, false);
    

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}