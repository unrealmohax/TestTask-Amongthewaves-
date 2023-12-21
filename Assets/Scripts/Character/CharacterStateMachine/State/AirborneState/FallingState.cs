using Assets.Character.Configs;
using UnityEngine;

namespace StateMachine.State
{
    internal class FallingState : AirborneState
    {
        private readonly GroundChecker _groundChecker;
        private readonly WallChecker _wallChecker;
        private readonly HardLandingStateConfig _hardLandingStateConfig;

        protected new const float DecelerationFactor = 0.005f;

        internal FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _groundChecker = character.GroundChecker;
            _wallChecker = character.WallChecker;
            _hardLandingStateConfig = character.Config.HardLandingStateConfig;
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();
            View.StartFalling();
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();
            View.StopFalling();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.LeftShift) && DashReady())
            {
                StateSwitcher.SwitchState<DashState>();
                return;
            }

            if (_groundChecker.IsTouches)
            {
                if (Mathf.Abs(Rigidbody.velocity.y) >= _hardLandingStateConfig.SpeedForStartHardLanding)
                    StateSwitcher.SwitchState<HardLandingState>();
                else if (IsHorizontalVelocityZero)
                    StateSwitcher.SwitchState<IdlingState>();
                else
                    StateSwitcher.SwitchState<RunningState>();
            }

            if (_wallChecker.IsTouchesWall)
            {
                StateSwitcher.SwitchState<SlideOnWallState>();
            }
        }

        protected override float GetVelocityInput()
        {
            return (Mathf.Abs(HorizontalInput) > 0) ? Mathf.Lerp(Data.CurrentSpeed, Data.Speed * HorizontalInput, AccelerationFactor) : Data.CurrentSpeed = Mathf.Lerp(Data.CurrentSpeed, 0f, DecelerationFactor);
        }

        private bool DashReady()
        {
            return Data.DashTime <= 0;
        }
    }
}
