public class IdleState : MovementState
{
    #region PUBLIC
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }


    public override void Update()
    {
        base.Update();

        if (IsDirectionZero())
            return;

        StateSwitcher.SwitchState<WalkingState>();
    }
    #endregion

    #region PRIVATE

    #endregion

}
