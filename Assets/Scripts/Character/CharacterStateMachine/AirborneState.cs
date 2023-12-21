using Assets.Character.Configs;

namespace StateMachine.State
{
    public class AirborneState : MovementState
    {
        private readonly AirborneStateConfig _config;

        public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.AirborneStateConfig;

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();
            View.StartAirborne();
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();
            View.StopAirborne();
        }
    }
}