using UnityEngine;

namespace StateMachine.State
{
    public class GroundedState : MovementState
    {
        protected readonly BoxChecker BoxChecker;
        protected readonly GroundChecker GroundChecker;
        private Quaternion TurnRight => Quaternion.Euler(0, 90, 0);
        private Quaternion TurnLeft => Quaternion.Euler(0, -90, 0);

        public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            GroundChecker = character.GroundChecker;
            BoxChecker = character.BoxChecker;
        }

        protected override void StartAnimation()
        {
            base.StartAnimation();
            View.StartGrounded();
        }

        protected override void StopAnimation()
        {
            base.StopAnimation();
            View.StopGrounded();
        }

        public override void Update()
        {
            base.Update();

            var velocity = GetConvertedVecloity();
            Rotate(HorizontalInput);

            if (GroundChecker.IsTouches == false)
                StateSwitcher.SwitchState<FallingState>();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StateSwitcher.SwitchState<JumpingState>();
            }
        }

        protected virtual void Rotate(float velocity)
        {
            CharacterTransform.transform.rotation = GetRotationFrom(velocity);
        }

        private Quaternion GetRotationFrom(float velocity)
        {
            if (velocity > 0)
                return TurnRight;

            if (velocity < 0)
                return TurnLeft;

            return CharacterTransform.transform.rotation;
        }
    }
}