using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PickupsConfig _pickupsConfig;

    [SerializeField] private ButchersGames.LevelManager _levelManager;
    [SerializeField] private Level _level;
    [SerializeField] private Character _character;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private ChangeUpgrade _changeUpgrade;
    [SerializeField] private TriggerRotate _triggerRotate;
    [SerializeField] private TriggerDoors _triggerDoors;
    #region PUBLIC

    #endregion

    #region PRIVATE
    private void Awake()
    {
        _levelManager.Init();
        _character.Initialize();
        _input.Initialize();
        _upgrades.Initialize(_pickupsConfig);
        _changeUpgrade.Initialize(_upgrades);
        _triggerRotate.Initialize();
        _triggerDoors.openDoor.AddListener(_level.Finish);
    }

    private void OnDestroy()
    {
        _triggerDoors.openDoor.RemoveListener(_level.Finish);

    }
    #endregion
}
