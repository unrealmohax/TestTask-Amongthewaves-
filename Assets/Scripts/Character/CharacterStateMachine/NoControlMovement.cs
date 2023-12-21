using UnityEngine;

namespace StateMachine.State
{
    internal class NoControlMovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        protected readonly Character Character;

        internal NoControlMovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            Character = character;
        }

        protected Transform Transform => Character.transform;
        protected Rigidbody Rigidbody => Character.Rigidbody;
        protected CharacterView View => Character.View;
        protected Transform CharacterTransform => Character.transform;
        protected bool IsHealthZero => Data.Health <= 0f;
        protected GroundChecker GroundChecker => Character.GroundChecker;
        protected WallChecker WallChecker => Character.WallChecker;
        protected const float DecelerationFactor = 0.05f;

        public virtual void Enter()
        {
            Debug.Log(GetType());

            StartAnimation();
        }

        public virtual void Exit()
        {
            StopAnimation();
        }

        public virtual void HandleInput()
        {
            Data.CurrentSpeed = GetVelocityInput();
        }

        public virtual void Update()
        {
            Data.TimeLastJump += Time.deltaTime;
            Data.DashTime -= Time.deltaTime;

            if (IsHealthZero && !(StateSwitcher.CurrentState is DyingState))
            {
                StateSwitcher.SwitchState<DyingState>();
            }
        }

        public virtual void FixedUpdate()
        {
            Vector2 velocity = GetConvertedVecloity();

            Rigidbody.velocity = velocity;
        }
        protected virtual void StartAnimation()
        {
            View.StartNoControlMovement();
        }

        protected virtual void StopAnimation()
        {
            View.StopNoControlMovement();
        }
        protected virtual float GetVelocityInput() => Data.CurrentSpeed = Mathf.Lerp(Data.CurrentSpeed, 0f, DecelerationFactor);
        protected bool IsHorizontalVelocityZero() => Mathf.Abs(Data.CurrentSpeed) <= 0.01;
        protected bool ReadRunInput() => Input.GetKey(KeyCode.LeftShift);
        protected Vector3 GetConvertedVecloity() => new Vector3(Data.CurrentSpeed, Rigidbody.velocity.y, 0);
    }
}
