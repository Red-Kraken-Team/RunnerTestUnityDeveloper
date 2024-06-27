using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private StateMachineData _machineData;
    [SerializeField] private Joystick _joystick;
    private Character _character;

    #region PUBLIC
    public void Initialize()
    {
        if (TryGetComponent(out Character character))
            _character = character;

        _joystick.AxisOptions = AxisOptions.Horizontal;

    }
    
    #endregion

    #region PRIVATE
    private void Update()
    {
        if (_character.IsMove)
            _character.StateMachineData.SetMoveX(_joystick.Horizontal);
        else
            _character.StateMachineData.SetMoveX(0);
    }
    #endregion
}
