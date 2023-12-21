public interface IStateSwitcher
{
    IState PrevState { get; }
    IState CurrentState { get; }
    void SwitchState<State>() where State : IState;
}