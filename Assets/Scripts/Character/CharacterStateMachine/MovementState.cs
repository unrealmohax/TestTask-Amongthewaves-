using UnityEngine;

namespace StateMachine.State
{
    public class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;

        protected Character _character;
        protected const string Horizontal = "Horizontal";
        protected const float AccelerationFactor = 0.05f;
        protected const float DecelerationFactor = 0.5f;

        public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            _character = character;
        }

        protected Rigidbody Rigidbody => _character.Rigidbody;
        protected CharacterView View => _character.View;
        protected Transform CharacterTransform => _character.transform;

        protected float HorizontalInput => Input.GetAxis(Horizontal);
        protected bool IsHorizontalVelocityZero => Input.GetAxis(Horizontal) == 0f;
        protected bool IsHealthZero => Data.Health <= 0f;

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
            View.SetMovementVelocity(Mathf.Abs(velocity.x));
        }
        protected virtual void StartAnimation()
        {
            View.StartMovement();
        }

        protected virtual void StopAnimation()
        {
            View.StopMovement();
        }

        protected bool ReadRunInput() => Input.GetKey(KeyCode.LeftShift);
        protected Vector3 GetConvertedVecloity() => new Vector3(Data.CurrentSpeed, Rigidbody.velocity.y, 0);
        protected virtual float GetVelocityInput() => (Mathf.Abs(HorizontalInput) > 0) ? Mathf.Lerp(Data.CurrentSpeed, Data.Speed * HorizontalInput, AccelerationFactor) : Data.CurrentSpeed = Mathf.Lerp(Data.CurrentSpeed, 0f, DecelerationFactor);
        
    }
}