using UnityEngine;
using System;

[Serializable]
public class WalkingConfig
{
    #region PUBLIC
	[field: SerializeField, Range(0, 10)] public float WalkingSpeed { get; private set; }
    [field: SerializeField, Range(0, 20)] public float SideSpeed { get; private set; }

    [field: SerializeField, Range(.5f, 1f)] public float RotateDuration { get; private set; }
    #endregion

    #region PRIVATE

    #endregion
}
