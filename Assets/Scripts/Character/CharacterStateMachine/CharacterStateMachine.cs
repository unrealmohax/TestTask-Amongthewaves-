using StateMachine.State;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public class CharacterStateMachine : IStateSwitcher
    {
        public StateMachineData Data { get; private set; }

        public IState CurrentState => _currentState;
        public IState PrevState => _prevState;

        private List<IState> _states;
        private IState _currentState;
        private IState _prevState;

        public CharacterStateMachine(Character character)
        {
            Data = new StateMachineData(character.Config);

            _states = new List<IState>()
            {
                new IdlingState(this, Data, character),
                new WalkingState(this, Data, character),
                new PushingState(this, Data, character),
                new RunningState(this, Data, character),
                new JumpingState(this, Data, character),
                new FallingState(this, Data, character),
                new SlideOnWallState(this, Data, character),
                new RunningTurn(this, Data, character),
                new TackleState(this, Data, character),
                new JumpingOnWallState(this, Data, character),
                new HardLandingState(this, Data, character),
                new DashState(this, Data, character),
                new DyingState(this, Data, character),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<State>() where State : IState
        {
            IState state = _states.FirstOrDefault(state => state is State);

            _prevState = _currentState;
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void HandleInput() => _currentState.HandleInput();

        public void Update() => _currentState.Update();

        public void FixedUpdate() => _currentState.FixedUpdate();
    }
}