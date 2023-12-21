using System.Collections;
using UnityEngine;

public class SpikeTrapAnimation : MonoBehaviour 
{

    [SerializeField] private Animator _animator;
    [SerializeField, Range(0.01f, 100f)] private float _timeOpenState;
    [SerializeField, Range(0.01f, 100f)] private float _timeCloseState;

#if UNITY_EDITOR
    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }
#endif

    private void Start()
    {
        _animator = _animator != null ? _animator  : GetComponent<Animator>();

        StartCoroutine(OpenCloseTrap());
    }


    private IEnumerator OpenCloseTrap()
    {
        while (true)
        {
            _animator.SetTrigger("open");

            yield return new WaitForSeconds(_timeOpenState);

            _animator.SetTrigger("close");

            yield return new WaitForSeconds(_timeCloseState);
        }
    }
}