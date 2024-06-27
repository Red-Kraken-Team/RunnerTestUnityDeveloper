using UnityEngine;

public abstract class TriggerEnter : MonoBehaviour
{
    [field: SerializeField] public LayerMask TriggerLayer { get; private set; }

    protected void OnTriggerEnter(Collider other)
    {
        if ((TriggerLayer & (1 << other.gameObject.layer)) == 0)
            return;
        OnTriggerEnterInLayer(other.gameObject);
    }

    protected abstract void OnTriggerEnterInLayer(GameObject obj);

}
