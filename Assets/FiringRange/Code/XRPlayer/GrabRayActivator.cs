using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRInput
{
    public class GrabRayActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _leftGrabRay;
        [SerializeField] private GameObject _rightGrabRay;

        [SerializeField] private XRDirectInteractor _rightDirectGrab;
        [SerializeField] private XRDirectInteractor _leftDirectGrab;

        private void Awake()
        {
            _leftDirectGrab.selectEntered.AddListener(DisableLeftGrabRay);
            _leftDirectGrab.selectExited.AddListener(EnableLeftGrabRay);
            _rightDirectGrab.selectEntered.AddListener(DisableRightGrabRay);
            _rightDirectGrab.selectExited.AddListener(EnableRightGrabRay);
        }

        private void DisableLeftGrabRay(SelectEnterEventArgs args) => _leftGrabRay.SetActive(false);

        private void DisableRightGrabRay(SelectEnterEventArgs args) => _rightGrabRay.SetActive(false);

        private void EnableLeftGrabRay(SelectExitEventArgs args) => _leftGrabRay.SetActive(true);

        private void EnableRightGrabRay(SelectExitEventArgs args) => _rightGrabRay.SetActive(true);
    }
}
