public class WalkingState : MovementState
{
    private WalkingConfig _walkingConfig;

    #region PUBLIC
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _walkingConfig = character.CharacterConfig.WalkingConfig;
    }

    public override void Update()
    {
        base.Update();

        if (IsDirectionZero())
            StateSwitcher.SwitchState<IdleState>();
    }
    #endregion

    #region PRIVATE
    
    #endregion

}
