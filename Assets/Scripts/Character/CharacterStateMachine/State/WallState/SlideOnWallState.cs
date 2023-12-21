using UnityEngine;
using Assets.Character.Configs;

namespace StateMachine.State
{
    internal class SlideOnWallState : WallState
    {
        internal SlideOnWallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
        }

        public override void Enter()
        {
            base.Enter();

            View.StartSlideOnWall();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopSlideOnWall();
        }

        public override void Update()
        {
            base.Update();

            Rigidbody.velocity = GetSlideWallVelocity();

            if (GroundChecker.IsTouches)
            {
                StateSwitcher.SwitchState<IdlingState>();
                return;
            }

            if (WallChecker.IsTouchesWall)
            {
                if (Input.GetKey(KeyCode.Space) && Data.TimeLastJump >= JumpingOnWallStateConfig.CooldownJumping)
                {
                    StateSwitcher.SwitchState<JumpingOnWallState>();
                }
            }
            else if (Rigidbody.velocity.y <= 0)
            {
                StateSwitcher.SwitchState<FallingState>();
            }
        }

        private Vector3 GetSlideWallVelocity()
        {
            Vector3 forwardMove = Rigidbody.transform.forward;
            forwardMove.y = SlideWallStateConfig.Speed;
            return forwardMove;
        }
    }
}