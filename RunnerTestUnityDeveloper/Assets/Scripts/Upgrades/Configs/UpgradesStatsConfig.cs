using UnityEngine;
using System;

[Serializable]
public class UpgradesStatsConfig
{
    [SerializeField, Min(1)] private int _startUpgradeLevel;
    [SerializeField, Min(2)] private int _maxUpgradeLevel;
    [SerializeField, Min(1)] private int _upgradeStep;

    public int StartUpgradeLevel => _startUpgradeLevel;
    public int MaxUpgradeLevel => _maxUpgradeLevel;
    public int UpgradeStep => _upgradeStep;

}
