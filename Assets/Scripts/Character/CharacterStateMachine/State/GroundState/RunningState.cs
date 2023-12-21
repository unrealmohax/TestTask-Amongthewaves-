using UnityEngine;
using Assets.Character.Configs;

namespace StateMachine.State
{
    public class RunningState : GroundedState
    {
        private readonly RunningStateConfig _config;

        public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.RunningStateConfig;

        private bool _lastTurnVelocity;

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;
            _lastTurnVelocity = Input.GetAxis(Horizontal) > 0;
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                StateSwitcher.SwitchState<TackleState>();
                return;
            }

            /*if (_lastTurnVelocity != Input.GetAxis(Horizontal) > 0)
            {
                StateSwitcher.SwitchState<RunningTurn>();
                return;
            }*/

            if (IsHorizontalVelocityZero)
                StateSwitcher.SwitchState<IdlingState>();
            else if (BoxChecker.IsTouches)
                StateSwitcher.SwitchState<PushingState>();
            else if (!ReadRunInput())
                StateSwitcher.SwitchState<WalkingState>();
        }
    }
}