using Assets.Character.Configs;
using UnityEngine;

namespace StateMachine.State
{
    internal class TackleState : NoControlMovementState
    {
        private readonly TackleStateConfig _config;

        internal TackleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.TackleStateConfig;

        public override void Enter()
        {
            base.Enter();

            Data.CurrentSpeed = GetTackleVelocity();
            Data.TackleTime = 0;

            View.StartTackle();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopTackle();
        }

        public override void Update()
        {
            base.Update();

            Data.CurrentSpeed = GetTackleVelocity();
            Data.TackleTime += Time.deltaTime;

            if (Data.TackleTime >= _config.TackleDuraction || IsHorizontalVelocityZero())
            {
                if (IsHorizontalVelocityZero())
                    StateSwitcher.SwitchState<IdlingState>();

                if (ReadRunInput())
                    StateSwitcher.SwitchState<RunningState>();
                else
                    StateSwitcher.SwitchState<WalkingState>();
            }
        }

        private float GetTackleVelocity() => (_config.Speed * Transform.forward).x;
        
    }
}