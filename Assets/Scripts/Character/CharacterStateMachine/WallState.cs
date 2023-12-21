using Assets.Character.Configs;

namespace StateMachine.State
{
    internal class WallState : NoControlMovementState
    {
        protected readonly SlideWallStateConfig SlideWallStateConfig;
        protected readonly JumpingOnWallStateConfig JumpingOnWallStateConfig;

        internal WallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            SlideWallStateConfig = character.Config.SlideWallStateConfig;
            JumpingOnWallStateConfig = character.Config.JumpingOnWallStateConfig;
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();
            View.StartWallContact();
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();
            View.StopWallContact();
        }
    }
}