using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class TriggerRotate : TriggerEnter
{
    [SerializeField] private CharacterConfig _characterConfig;
    private Character _character;

    private float RotateDuration => _characterConfig.WalkingConfig.RotateDuration;

    private Coroutine _rotateCoroutine;

    #region PUBLIC

    public void Initialize()
    {
        _character = GetComponent<Character>();
    }

    protected override void OnTriggerEnterInLayer(GameObject other)
    {
        StartRotateToTarget(other.transform);
    }
    #endregion

    #region PRIVATE
    private void StartRotateToTarget(Transform target)
    {
        if (_rotateCoroutine != null)
            return;
        
        StartCoroutine(RotateToTarget(target));
    }

    private IEnumerator RotateToTarget(Transform target)
    {
        float time = 0, duration = RotateDuration;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z));

        _character.MoveStop();

        while (time < duration)
        {
            float t = Mathf.Lerp(0, 1, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            time += Time.deltaTime;
            yield return null;
        }

        _character.MoveStart();
    }

    #endregion



}
