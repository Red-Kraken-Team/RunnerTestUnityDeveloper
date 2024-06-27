using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private ChangeUpgrade _changeUpgrade;

    #region PUBLIC

    #endregion

    #region PRIVATE
    private void Awake()
    {
        _character.Initialize();
        _input.Initialize();
        _upgrades.Initialize();
        _changeUpgrade.Initialize(_upgrades);
    }
    #endregion
}
