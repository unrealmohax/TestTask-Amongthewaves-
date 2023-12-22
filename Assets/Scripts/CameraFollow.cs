using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _damping = 5f;
    private Vector3 _offset;
    private const float _minDistance = 0.2f;

    private void Start()
    {
        SetOffset();
    }

    private void SetOffset()
    {
        _offset = transform.position - _target.position;
    }

    public void SetTarget(Transform target)
    {
        if (target == null) return;

        _target = target;
        SetOffset();
    }

    public void SetPositionX(float positionX)
    {
        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        SetOffset();
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            Vector3 targetPosition = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, transform.position.z);

            if (Mathf.Abs(targetPosition.y - transform.position.y) < _minDistance)
                targetPosition.y = transform.position.y;

            Vector3 currentPosition = Vector3.Lerp(transform.position, targetPosition, _damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}