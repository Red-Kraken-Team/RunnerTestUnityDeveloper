using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickupNotified
{
    #region PUBLIC
    public event Action<Pickup> AddNotified;
    public event Action<Pickup> RemoveNotified;

    public abstract void Accept(IPickupVisitor pickupVisitor);

    public virtual void Use() => AddNotified?.Invoke(this);

    private void OnDestroy() => RemoveNotified?.Invoke(this);
    

    #endregion

    #region PRIVATE
    #endregion
}
