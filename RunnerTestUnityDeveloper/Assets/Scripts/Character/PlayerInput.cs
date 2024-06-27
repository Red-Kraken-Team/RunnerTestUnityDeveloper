using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private StateMachineData _machineData;
    [SerializeField] private Joystick _joystick;

    #region PUBLIC
    public void Initialize()
    {
        if (TryGetComponent(out Character character))
            _machineData = character.StateMachine.StateMachineData;

        _joystick.AxisOptions = AxisOptions.Horizontal;
    }
    #endregion

    #region PRIVATE
    private void Update()
    {
        Vector2 direction = new Vector2( _joystick.Horizontal, 1);

        _machineData.SetMoveDirection(direction);
    }
    #endregion
}
