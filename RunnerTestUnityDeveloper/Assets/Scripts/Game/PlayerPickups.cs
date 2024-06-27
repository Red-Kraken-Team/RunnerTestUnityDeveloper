using System;
using UnityEngine;

public class PlayerPickups
{
    [SerializeField] private PickupsConfig _pickupsConfig;
    public PickupsConfig PickupsConfig => _pickupsConfig;

    public int Value => _pickupVisitor.Score;

    private PickupVisitor _pickupVisitor;

    public PlayerPickups(PickupsConfig pickupsConfig)
    {
        _pickupsConfig = pickupsConfig;
        _pickupVisitor = new PickupVisitor(pickupsConfig);
    }

    public void AddToPickupNotified(IPickupNotified pickupNotified) => pickupNotified.AddNotified += PickupNotified;

    public void RemovePickupNotified(IPickupNotified pickupNotified) => pickupNotified.RemoveNotified -= PickupNotified;

    private void PickupNotified(Pickup pickup)
    {
        pickup.Accept(_pickupVisitor);

        Debug.Log(Value);
    }


    #region PUBLIC

    #endregion

    #region PRIVATE

    #endregion

    private class PickupVisitor : IPickupVisitor
    {
        public int Score { get; private set; }

        private PickupsConfig _pickupsConfig;

        public PickupVisitor(PickupsConfig pickupsConfig)
        {
            _pickupsConfig = pickupsConfig;
            Score = _pickupsConfig.UpgradeConfig.StartUpgradeLevel;
        }

        public void Visit(Booster booster) => Score += _pickupsConfig.BoosterScore;


        public void Visit(Reducer reducer) => Score -= _pickupsConfig.ReduserScore;
    }


}
