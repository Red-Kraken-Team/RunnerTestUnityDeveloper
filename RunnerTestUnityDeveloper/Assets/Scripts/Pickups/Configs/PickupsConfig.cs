using UnityEngine;

[CreateAssetMenu(fileName = "PickupsConfig", menuName = "Configs/PickupsConfig")]
public class PickupsConfig : ScriptableObject
{
    [SerializeField, Min(0)] private int _boosterScore;
    [SerializeField, Min(0)] private int _reducerScore;

    public int BoosterScore => _boosterScore;
    public int ReduserScore => _reducerScore;

    [SerializeField] private UpgradesStatsConfig _statsConfig;

    public UpgradesStatsConfig UpgradeConfig => _statsConfig;

    #region PUBLIC

    #endregion

    #region PRIVATE

    #endregion
}
