using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoors : TriggerEnter
{
    public UnityEvent openDoor;
    //private PlayerPickups _playerPickups;

    #region PUBLIC

    //public void Initialize(PlayerPickups playerPickups)
    //{
    //    _playerPickups = playerPickups;
    //}

    protected override void OnTriggerEnterInLayer(GameObject obj)
    {
        if (openDoor != null)
            openDoor.Invoke();
    }
    #endregion

    #region PRIVATE

    #endregion

}
