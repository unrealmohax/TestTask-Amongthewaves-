using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField, Range(1, 100f)] private float _damage;
    private void OnTriggerEnter(Collider other)
    {
        var damagable = other.gameObject.GetComponentInParent<IDamagable>();
        damagable?.Damage(_damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damagable = collision.gameObject.GetComponentInParent<IDamagable>();
        damagable?.Damage(_damage);
    }
}
