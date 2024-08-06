using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        private const string LeftHandTag = "Left Hand";
        private const string RightHandTag = "Right Hand";
        [SerializeField] private Transform _leftAttachTransform;
        [SerializeField] private Transform _rightAttachTransform;
        
        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            if (args.interactorObject.transform.CompareTag(LeftHandTag))
                attachTransform = _leftAttachTransform;
            else if (args.interactorObject.transform.CompareTag(RightHandTag)) 
                attachTransform = _rightAttachTransform;
            base.OnSelectEntering(args);
        }
    }
}
