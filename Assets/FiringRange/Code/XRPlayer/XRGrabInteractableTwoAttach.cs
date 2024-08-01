using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        public event Action OnGrab;
        public event Action OnDrop;
        private const string LeftHandTag = "Left Hand";
        private const string RightHandTag = "Right Hand";
        [SerializeField] private Transform _leftAttachTransform;
        [SerializeField] private Transform _rightAttachTransform;
        
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (attachTransform is null)
            {
                if (args.interactorObject.transform.CompareTag(LeftHandTag))
                    attachTransform = _leftAttachTransform;
                else if (args.interactorObject.transform.CompareTag(RightHandTag))
                    attachTransform = _rightAttachTransform;
            }

            OnGrab?.Invoke();
            base.OnSelectEntered(args);
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            OnDrop?.Invoke();
            base.OnSelectExited(args);
        }
    }
}
