using UnityEngine;
using System;

public class StateMachineData
{
    private Vector2 _moveDirection;

    #region PUBLIC

    public Vector2 MoveDirection
    {
        get { return _moveDirection; }
        private set {  }
    }



    public void SetMoveDirection(Vector2 direction) => _moveDirection = Vector2.ClampMagnitude(direction, 1);

    public void SetMoveX(float x) => _moveDirection = new Vector2(Mathf.Clamp(x, -1, 1), _moveDirection.y);

    public void SetMoveY(float y) => _moveDirection = new Vector2(_moveDirection.x, Mathf.Clamp(y, -1, 1));

    #endregion

    #region PRIVATE

    #endregion
}
