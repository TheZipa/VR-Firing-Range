using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class XRIgnoreSelectedDirectInteractor : XRDirectInteractor
    {
        [SerializeField] private XRDirectInteractor _anotherHandInteractor;

        public override bool CanSelect(IXRSelectInteractable interactable)
        {
            if (_anotherHandInteractor.hasSelection &&
                _anotherHandInteractor.interactablesSelected.First() == interactable)
                return false;
            return base.CanSelect(interactable);
        }
    }
}