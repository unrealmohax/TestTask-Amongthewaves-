using Assets.Character.Configs;

namespace StateMachine.State
{
    public class WalkingState : GroundedState
    {
        private readonly WalkingStateConfig _config;

        public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.WalkingStateConfig;

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalVelocityZero)
                StateSwitcher.SwitchState<IdlingState>();
            else if (BoxChecker.IsTouches)
                StateSwitcher.SwitchState<PushingState>();
            else if (ReadRunInput())
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}