using UnityEngine;

namespace StateMachine.State
{
    internal class DyingState : IState
    {
        private Character _character;
        private IStateSwitcher _stateSwitcher;
        private StateMachineData _data;
        internal DyingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)  
        {
            _stateSwitcher = stateSwitcher;
            _data = data;
            _character = character;
        }

        private float timeDie;

        public void Enter()
        {
            _data.Speed = 0;
            timeDie = 0;

            _character.Rigidbody.isKinematic = true;
            _character.View.StartDying();
        }

        public void Exit()
        {
            _character.Rigidbody.isKinematic = false;
            _character.View.StopDying();
        }

        public void Update()
        {
            timeDie += Time.deltaTime;

            if (timeDie > 1)
            {
                _character.ResetCharacter();
                _stateSwitcher.SwitchState<IdlingState>();
            }
        }

        public void HandleInput()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}

