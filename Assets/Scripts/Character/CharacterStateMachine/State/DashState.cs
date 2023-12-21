using Assets.Character.Configs;
using UnityEngine;

namespace StateMachine.State
{
    internal class DashState : NoControlMovementState
    {
        private readonly DashStateConfig _config;
        private readonly WallChecker _wallChecker;

        internal DashState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _wallChecker = character.WallChecker;
            _config = character.Config.DashStateConfig;
        }


        private float _timeDash;
        private float _cachedRigidbodyVelocity;
        private Vector3 _dashSpeed;
        private bool _isDashFinished => _timeDash >= _config.MaxDashTime;

        public override void Enter()
        {
            base.Enter();

            _timeDash = 0;
            _cachedRigidbodyVelocity = Rigidbody.velocity.x;
            _dashSpeed = _config.Speed * Rigidbody.transform.forward;
        }

        public override void Exit()
        {
            base.Exit();
            Data.DashTime = _config.RefreshDashTime;
            Rigidbody.velocity = new Vector3(_cachedRigidbodyVelocity, 0, 0);
        }

        protected override void StartAnimation()
        {
            View.StartDash();
        }

        protected override void StopAnimation()
        {
            View.StopDash();
        }

        public override void Update()
        {
            base.Update();

            _timeDash += Time.deltaTime;

            if (!_isDashFinished)
            {
                Data.CurrentSpeed = _dashSpeed.x;
            }
            else
            {
                if (_wallChecker.IsTouchesWall)
                {
                    StateSwitcher.SwitchState<SlideOnWallState>();
                }

                if (Rigidbody.velocity.y < 0)
                {
                    StateSwitcher.SwitchState<FallingState>();
                }
            }
        }
    }
}
