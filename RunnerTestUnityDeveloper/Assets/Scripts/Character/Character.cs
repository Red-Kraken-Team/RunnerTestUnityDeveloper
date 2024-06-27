using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;
    public CharacterConfig CharacterConfig => _characterConfig;

    public CharacterController CharacterController { get; private set; }
    public CharacterStateMachine StateMachine { get; private set; }
    public StateMachineData StateMachineData => StateMachine.StateMachineData;

    public bool IsMove { get; private set; }


    #region PUBLIC
    public void Initialize()
    {
        CharacterController = GetComponent<CharacterController>();
        StateMachine = new CharacterStateMachine(this);
    }

    public void MoveStart()
    {
        if (IsMove == false)
        {
            StateMachineData.SetMoveY(1);
            IsMove = true;
        }
    }

    public void MoveStop()
    {
        if (IsMove)
        {
            StateMachineData.SetMoveY(0);
            IsMove = false;
        }
    }
    
    #endregion

    #region PRIVATE

    private void Update()
    {
        StateMachine.Update();
    }
    #endregion
}
