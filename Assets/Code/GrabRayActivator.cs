using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Code
{
    public class GrabRayActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _leftGrabRay;
        [SerializeField] private GameObject _rightGrabRay;

        [SerializeField] private XRDirectInteractor _rightDirectGrab;
        [SerializeField] private XRDirectInteractor _leftDirectGrab;

        private void Update()
        {
            _leftGrabRay.SetActive(_leftDirectGrab.interactablesSelected.Count == 0);
            _rightGrabRay.SetActive(_rightDirectGrab.interactablesSelected.Count == 0);
        }
    }
}
