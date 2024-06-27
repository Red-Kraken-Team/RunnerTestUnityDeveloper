using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkingConfig _walkingConfig;

    public WalkingConfig WalkingConfig => _walkingConfig;

    #region PUBLIC
	
    #endregion

    #region PRIVATE
	
    #endregion
}
