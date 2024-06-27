using UnityEngine;
using UnityEngine.Events;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private PickupsConfig _pickupsConfig;
    private UpgradesStatsConfig UpgradeConfig => _pickupsConfig.UpgradeConfig;

    private PlayerPickups _playerPickups;
    public int CurrentLevel => _playerPickups.Value;


    public UnityEvent FailedUpgrades = new UnityEvent();
    public UnityEvent LevelChange = new UnityEvent();

    public int CurrentUpgrade { get; private set; }
    private int NextUpgrade => CurrentUpgrade * UpgradeConfig.UpgradeStep;
    private int PreviousUpgrade => NextUpgrade - UpgradeConfig.UpgradeStep;

    #region PUBLIC
    public void Initialize()
    {
        _playerPickups = new PlayerPickups(_pickupsConfig);
        AddPickupNotified();

        CurrentUpgrade = 1;
    }

    

    #endregion

    #region PRIVATE
	private void AddPickupNotified()
    {
        IPickupNotified[] list = FindObjectsByType<Pickup>(FindObjectsSortMode.None);
        foreach (var notified in list)
        {
            _playerPickups.AddToPickupNotified(notified);
            _playerPickups.RemovePickupNotified(notified);

            notified.AddNotified += ChangeCurrentLevel;
        }
    }

    private void ChangeCurrentLevel(Pickup pickup)
    {
        if(CurrentLevel <= 0)
        {
            FailedUpgrades?.Invoke();
            return;
        }

        if (CurrentLevel >= UpgradeConfig.MaxUpgradeLevel)
        {
            return;
        }

        if(CurrentLevel >= NextUpgrade)
        {
            LevelUp();
            return;
        }

        if(CurrentLevel <= PreviousUpgrade)
        {
            LevelDown();
        }
    }

    private void LevelUp()
    {
        Debug.Log("Level Up " + CurrentLevel + " " + NextUpgrade);
        CurrentUpgrade++;

        LevelChange?.Invoke();
    }

    private void LevelDown()
    {
        Debug.Log("Level Down " + CurrentLevel + " " + PreviousUpgrade);
        CurrentUpgrade--;

        LevelChange?.Invoke();
    }

    

    
    #endregion
}
