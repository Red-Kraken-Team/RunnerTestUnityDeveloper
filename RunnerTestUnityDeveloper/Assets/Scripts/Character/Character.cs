using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    public CharacterController CharacterController { get; private set; }

    public CharacterConfig CharacterConfig => _characterConfig;

    public CharacterStateMachine StateMachine { get; private set; }

    private bool _isMove;

    #region PUBLIC
    public void Initialize()
    {
        CharacterController = GetComponent<CharacterController>();
        StateMachine = new CharacterStateMachine(this);
    }

    public void MoveStart()
    {
        if (_isMove == false)
            _isMove = true;
    }

    public void MoveStop()
    {
        if (_isMove)
            _isMove = false;
    }

    #endregion

    #region PRIVATE

    private void Update()
    {
        if(_isMove)
            StateMachine.Update();
    }
    #endregion
}
