using System;

public interface IPickupNotified
{
    event Action<Pickup> AddNotified;
    event Action<Pickup> RemoveNotified;

}
