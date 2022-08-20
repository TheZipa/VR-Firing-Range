using UnityEngine;
using UnityEngine.InputSystem;

namespace Code
{
    public class InputHandAnimation : MonoBehaviour
    {
        [SerializeField] private InputActionProperty _pinchAnimationAction;
        [SerializeField] private InputActionProperty _gripAnimationAction;
        [SerializeField] private Animator _handAnimator;

        private readonly int _triggerAnimationHash = Animator.StringToHash("Trigger");
        private readonly int _gripAnimationHash = Animator.StringToHash("Grip");

        private void Update()
        {
            float triggerValue = _pinchAnimationAction.action.ReadValue<float>();
            float gripValue = _gripAnimationAction.action.ReadValue<float>();

            InformHandAnimation(triggerValue, gripValue);
        }

        private void InformHandAnimation(float triggerValue, float gripValue)
        {
            _handAnimator.SetFloat(_triggerAnimationHash, triggerValue);
            _handAnimator.SetFloat(_gripAnimationHash, gripValue);
        }
    }
}
