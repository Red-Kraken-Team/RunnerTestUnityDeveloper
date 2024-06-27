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

    #endregion

    #region PRIVATE

    #endregion
}
