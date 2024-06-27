using UnityEngine;

[RequireComponent(typeof (Animator))]
public class ChangeUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] _upgradesMesh;

    private Upgrades _upgrades;

    private Animator _animator;
    private const string _changeUpgrade = "change";

    #region PUBLIC
	public void Initialize(Upgrades upgrades)
    {
        _upgrades = upgrades;
        _upgrades.LevelChange.AddListener(LevelChange);

        _animator = GetComponent<Animator>();
    }


    #endregion

    #region PRIVATE
    private void OnDestroy()
    {
        _upgrades.LevelChange.RemoveListener(LevelChange);
    }

    private void LevelChange()
    {
        DisableAllMeshes();
        EnableCurrentMesh();
    }

    private void DisableAllMeshes()
    {
        foreach (GameObject mesh in _upgradesMesh)
            if (mesh.activeSelf)
                mesh.SetActive(false);
    }

    private void EnableCurrentMesh()
    {
        if (_upgrades.CurrentUpgrade >= _upgradesMesh.Length)
            return;

        if (_upgradesMesh[_upgrades.CurrentUpgrade].activeSelf)
            return;

        _upgradesMesh[_upgrades.CurrentUpgrade].SetActive(true);

        _animator.SetInteger(_changeUpgrade, _upgrades.CurrentUpgrade);
    }
    #endregion
}
