using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Code
{
    public class XRSocketInteractorTag : XRSocketInteractor
    {
        [SerializeField] private string _interactTag;

        [Obsolete("CanSelect(XRBaseInteractable) has been deprecated. Use CanSelect(IXRSelectInteractable) instead.")]
        public override bool CanSelect(XRBaseInteractable interactable) =>
            base.CanSelect(interactable) && interactable.CompareTag(_interactTag);
    }
}
