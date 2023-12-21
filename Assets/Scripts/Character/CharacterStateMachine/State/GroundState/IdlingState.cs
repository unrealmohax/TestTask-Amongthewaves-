namespace StateMachine.State
{
    public class IdlingState : GroundedState
    {
        public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalVelocityZero)
                return;

            if (BoxChecker.IsTouches)
                StateSwitcher.SwitchState<PushingState>();
            else if (ReadRunInput())
                StateSwitcher.SwitchState<RunningState>();
            else
                StateSwitcher.SwitchState<WalkingState>();
        }
    }
}