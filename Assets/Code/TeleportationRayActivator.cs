using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Code
{
    public class TeleportationRayActivator : MonoBehaviour
    {
        [SerializeField] private XRRayInteractor _interactor;
        [SerializeField] private GameObject _rightHand;
        [SerializeField] private InputActionProperty _rightActivateInput;

        private void Awake() => _rightActivateInput.action.performed += OnInputActive;

        private void OnInputActive(InputAction.CallbackContext args)
        {
            float controllerInputAxis = args.ReadValue<Vector2>().y;
        }
    }
}