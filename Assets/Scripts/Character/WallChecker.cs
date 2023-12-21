using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public bool IsTouchesWall { get; private set; }

    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    private void Update() => IsTouchesWall = Physics.Raycast(transform.position, transform.forward.x > 0 ? Vector3.right : Vector3.left, _distanceToCheck, _layerMask);


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = transform.forward.x > 0 ? Vector3.right : Vector3.left;
        Gizmos.DrawLine(transform.position, transform.position + direction * _distanceToCheck);
    }
#endif
}