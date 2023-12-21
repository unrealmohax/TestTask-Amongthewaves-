using UnityEngine;

public class AnimEventListener : MonoBehaviour
{
    [SerializeField] private CharacterView _characterView;

    public void AnimationFinished()
    {
        _characterView.onAnimFinished?.Invoke();
    }

    public void JumpEvent() 
    {
        _characterView.onJumpEvent?.Invoke();
    }
}