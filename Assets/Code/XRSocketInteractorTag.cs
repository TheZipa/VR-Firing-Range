using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Code
{
    public class XRSocketInteractorTag : XRSocketInteractor
    {
        [SerializeField] private string _interactTag;

        public override bool CanSelect(XRBaseInteractable interactable) =>
            base.CanSelect(interactable) && interactable.CompareTag(_interactTag);
    }
}
