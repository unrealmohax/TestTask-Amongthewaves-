using Assets.Character.Configs;
using System;
using UnityEngine;

namespace StateMachine.State
{
    internal class JumpingState : AirborneState, IDisposable
    {
        private readonly AirborneStateConfig _config;
        private readonly DashStateConfig _dashConfig;
        private readonly WallChecker _wallChecker;
        private bool _isJump = true;

        internal JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _config = character.Config.AirborneStateConfig;
            _dashConfig = character.Config.DashStateConfig;
            _wallChecker = character.WallChecker;
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;
            Data.TimeLastJump = 0;
            _isJump = false;
            View.onJumpEvent.AddListener(Jump);
        }

        public override void Exit()
        {
            base.Exit();

            View.onJumpEvent.RemoveListener(Jump);
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();

            if (StateSwitcher.PrevState is IdlingState)
                View.StartJumpingOnPlace();
            else
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

            if (!_isJump) return;

            if (Input.GetKeyDown(KeyCode.LeftShift) && DashReady())
            {
                StateSwitcher.SwitchState<DashState>();
                return;
            }

            if (_wallChecker.IsTouchesWall && CanSlideOnWall())
            {
                StateSwitcher.SwitchState<SlideOnWallState>();
            }

            if (Rigidbody.velocity.y < 0)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }

        private bool DashReady() => Data.DashTime <= 0;

        private void Jump()
        {
            _isJump = true;

            Vector3 JumpForce = GetJumpForce();
            Rigidbody.AddForce(JumpForce, ForceMode.Impulse);
        }

        private bool CanSlideOnWall()
        {
            return Data.TimeLastJump > _config.JumpingStateConfig.MinDuractionJumping;
        }

        private Vector3 GetJumpForce()
        {
            float jumpForce = Mathf.Sqrt(-2 * _config.JumpingStateConfig.MaxHeight * Physics.gravity.y * Rigidbody.mass * Rigidbody.mass);

            return new Vector3(0, jumpForce, 0);
        }

        public void Dispose()
        {
            View.onJumpEvent.RemoveListener(Jump);
        }
    }
}