using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    public StateMachineData Data { get; private set; }

    private readonly Character _character;
    private CharacterConfig _characterConfig;

    private CharacterController CharacterController => _character.CharacterController;

    private float WalkingSpeed => _characterConfig.WalkingConfig.WalkingSpeed;
    private float SideSpeed => _characterConfig.WalkingConfig.SideSpeed;

    protected MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
        _characterConfig = character.CharacterConfig;
    }

    protected bool IsDirectionZero() => Data.MoveDirection == Vector2.zero;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        Vector3 velocity = new Vector3(Data.MoveDirection.x*SideSpeed, 0, Data.MoveDirection.y*WalkingSpeed);
        
        velocity = _character.transform.TransformDirection(velocity);


        CharacterController.Move(velocity * Time.deltaTime);

        if(IsDirectionZero())
            return;

        //_character.transform.forward = velocity.normalized;
    }

}
