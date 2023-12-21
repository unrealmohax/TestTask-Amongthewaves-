using UnityEngine;

public class BoxChecker : MonoBehaviour
{ 
    public bool IsTouches { get; private set; }
    public float BoxMass { get; private set; }

    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;
     
    private void Update()
    {
        IsTouches = Physics.Raycast(transform.position, transform.forward.x > 0 ? Vector3.right : Vector3.left, out RaycastHit hitInfo, _distanceToCheck, _layerMask);
        
        if (IsTouches) 
        {
            BoxMass = hitInfo.rigidbody.mass;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = transform.forward.x > 0 ? Vector3.right : Vector3.left;
        Gizmos.DrawLine(transform.position, transform.position + direction * _distanceToCheck);
    }
#endif
}
