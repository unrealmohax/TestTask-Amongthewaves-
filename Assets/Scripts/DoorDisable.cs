using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoorDisable : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObject;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _boxCollider.isTrigger = true;
        _rigidbody.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponentInParent<Character>();
        
        if (character != null)
        {
            m_gameObject?.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
