using System;

namespace StateMachine.State
{
    internal class HardLandingState : NoControlMovementState, IDisposable
    {
        private bool _isAnimFinished;

        internal HardLandingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) { }

        public override void Enter()
        {
            base.Enter();

            _isAnimFinished = false;
            Data.CurrentSpeed = 0;

            View.onAnimFinished.AddListener(AnimFinished);
            View.StartHardLanding();
        }

        public override void Exit()
        {
            base.Exit();

            View.onAnimFinished.RemoveListener(AnimFinished);
            View.StopHardLanding();
        }

        public override void Update()
        {
            base.Update();

            if (_isAnimFinished)
            {
                if (IsHorizontalVelocityZero())
                    StateSwitcher.SwitchState<IdlingState>();

                if (ReadRunInput())
                    StateSwitcher.SwitchState<RunningState>();
                else
                    StateSwitcher.SwitchState<WalkingState>();
            }
        }

        public void Dispose()
        {
            View.onAnimFinished.RemoveListener(AnimFinished);
        }


        private void AnimFinished() => _isAnimFinished = true;
    }


}
