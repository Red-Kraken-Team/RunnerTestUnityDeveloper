public interface IStateSwitcher 
{
    #region PUBLIC
    void SwitchState<T>() where T : IState;
    #endregion

    #region PRIVATE
	
    #endregion
}
