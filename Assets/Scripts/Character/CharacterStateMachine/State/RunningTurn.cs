using System;

namespace StateMachine.State
{
    internal class RunningTurn : NoControlMovementState, IDisposable
    {
        private bool _isRunningTurnFinished;

        internal RunningTurn(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) { }

        public override void Enter()
        {
            base.Enter();

            _isRunningTurnFinished = false;
            Data.Speed = 0;

            View.onAnimFinished.AddListener(RunningTurnFinished);
            View.StartRunningTurn();
        }

        public override void Exit()
        {
            base.Exit();

            View.onAnimFinished.RemoveListener(RunningTurnFinished);
            View.StopRunningTurn();
        }

        public override void Update()
        {
            base.Update();

            if (_isRunningTurnFinished)
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
            View.onAnimFinished.RemoveListener(RunningTurnFinished);
        }

        private void RunningTurnFinished() => _isRunningTurnFinished = true;
    }
}