using UnityEngine;

public class TriggerPickup : TriggerEnter
{

    #region PUBLIC
    

    protected override void OnTriggerEnterInLayer(GameObject other)
    {
        if (other.TryGetComponent(out Pickup pickup))
            pickup.Use();
    }


    #endregion

    #region PRIVATE

    #endregion

}
