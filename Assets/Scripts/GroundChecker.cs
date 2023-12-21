using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsTouches { get; private set; }

    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private float _maxDistance;

    private void Update() => IsTouches = Physics.BoxCast(transform.position, _boxSize * 0.5f, Vector3.down, Quaternion.identity, _maxDistance, _groundLayerMask);

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + Vector3.down * _maxDistance, _boxSize);
    }
#endif
}