using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public UnityEvent finishEvent = new UnityEvent();
    public UnityEvent failedEvent = new UnityEvent();

    #region PUBLIC
    public void Finish() => finishEvent?.Invoke();

    public void Failed() => failedEvent?.Invoke();

    public void RestartLevel() => SceneManager.LoadScene(0);
    #endregion

    #region PRIVATE

    #endregion
}
