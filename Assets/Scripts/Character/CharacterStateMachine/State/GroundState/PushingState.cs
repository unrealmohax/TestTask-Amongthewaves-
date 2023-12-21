using Assets.Character.Configs;

namespace StateMachine.State
{
    public class PushingState : GroundedState
    {
        private readonly PushingStateConfig _config;
        
        public PushingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.PushingStateConfig;

        public override void Enter()
        {
            base.Enter();
            Data.Speed = GetPushingSpeed();
        }

        private float GetPushingSpeed()
        {
            if (BoxChecker.BoxMass < 10)
                return _config.SpeedPushingLowMassObject;
            else if (BoxChecker.BoxMass >= 10 && BoxChecker.BoxMass < 20)
                return _config.SpeedPushingMiddleMassObject;
            else if (BoxChecker.BoxMass >= 20 && BoxChecker.BoxMass < 50)
                return _config.SpeedPushingBigMassObject;
            else
                return 0;
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();
            View.StartPushing(BoxChecker.BoxMass);
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();
            View.StopPushing();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalVelocityZero)
                StateSwitcher.SwitchState<IdlingState>();

            else if (!BoxChecker.IsTouches)
            {
                if (ReadRunInput())
                    StateSwitcher.SwitchState<RunningState>();
                else
                    StateSwitcher.SwitchState<WalkingState>();
            }
        }
    }
}