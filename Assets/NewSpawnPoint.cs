using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NewSpawnPoint : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    private void OnValidate()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _collider = _collider != null ? _collider : GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponentInParent<Character>();

        if (character != null)
        {
            character.SetSpawnPoint(transform.position);
            _collider.enabled = false;
        }
    }
}
