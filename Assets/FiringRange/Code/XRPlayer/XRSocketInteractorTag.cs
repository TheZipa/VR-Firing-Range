using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class XRSocketInteractorTag : XRSocketInteractor
    {
        [SerializeField] private string _interactTag;
        
        public override bool CanSelect(IXRSelectInteractable interactable) =>
            base.CanSelect(interactable) && interactable.transform.CompareTag(_interactTag);
    }
}
