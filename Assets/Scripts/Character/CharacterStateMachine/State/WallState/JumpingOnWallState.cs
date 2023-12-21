using Assets.Character.Configs;
using UnityEngine;

namespace StateMachine.State
{
    internal class JumpingOnWallState : WallState
    {
        internal JumpingOnWallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
        }

        private Quaternion TurnRight => Quaternion.Euler(0, 90, 0);
        private Quaternion TurnLeft => Quaternion.Euler(0, -90, 0);

        public override void Enter()
        {
            base.Enter();

            Data.TimeLastJump = 0;
            Jump();
        }

        public override void Exit() 
        {
            base.Exit();
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();

            View.StartJumping();
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();

            View.StopJumping();
        }

        public override void Update()
        {
            base.Update();

            if (GroundChecker.IsTouches)
            {
                StateSwitcher.SwitchState<IdlingState>();
            }
            else if(CanSlideOnWall())
            {
                StateSwitcher.SwitchState<SlideOnWallState>();
            }
            else if (Rigidbody.velocity.y < 0)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }
        protected  override float GetVelocityInput() => Data.CurrentSpeed;

        private void Jump()
        {
            Data.CurrentSpeed = (JumpingOnWallStateConfig.Speed * -CharacterTransform.forward).x;
            Vector3 JumpForce = GetJumpForce();

            Rigidbody.AddForce(JumpForce, ForceMode.Impulse);
            Rotate(Data.CurrentSpeed);
        }

        private void Rotate(float velocity)
        {
            CharacterTransform.rotation = GetRotationFrom(velocity);
        }

        private Quaternion GetRotationFrom(float velocity)
        {
            if (velocity > 0)
                return TurnRight;

            if (velocity < 0)
                return TurnLeft;

            return CharacterTransform.rotation;
        }

        private bool CanSlideOnWall()
        {
            return WallChecker.IsTouchesWall && Data.TimeLastJump > JumpingOnWallStateConfig.MinDuractionJumping;
        }

        private Vector3 GetJumpForce()
        {
            float jumpForce = Mathf.Sqrt(-2 * JumpingOnWallStateConfig.MaxHeight * Physics.gravity.y * Rigidbody.mass * Rigidbody.mass);
            return new Vector3(0, jumpForce, 0);
        }
    }
}