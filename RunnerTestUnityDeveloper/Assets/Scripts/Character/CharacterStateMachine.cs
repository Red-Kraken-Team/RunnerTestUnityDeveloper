using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public StateMachineData StateMachineData { get; private set; }

    #region PUBLIC
    public CharacterStateMachine(Character character)
    {
        StateMachineData = new StateMachineData();
        _states = new List<IState>
        {
            new IdleState(this, StateMachineData, character),
            new WalkingState(this, StateMachineData, character)
        };
        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(st => st is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }


    public void Update() => _currentState.Update();


    #endregion

    #region PRIVATE

    #endregion
}
