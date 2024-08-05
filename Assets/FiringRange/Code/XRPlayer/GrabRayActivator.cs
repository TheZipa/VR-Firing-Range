using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class GrabRayActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _leftGrabRay;
        [SerializeField] private GameObject _rightGrabRay;
        [SerializeField] private XRDirectInteractor _rightDirectGrab;
        [SerializeField] private XRDirectInteractor _leftDirectGrab;
        [SerializeField] private XRRayInteractor _leftRayInteractor;
        [SerializeField] private XRRayInteractor _rightRayInteractor;

        private void Awake()
        {
            _leftDirectGrab.selectEntered.AddListener(_ => _leftGrabRay.SetActive(false));
            _leftDirectGrab.selectExited.AddListener(_ => _leftGrabRay.SetActive(true));
            _rightDirectGrab.selectEntered.AddListener(_ => _rightGrabRay.SetActive(false));
            _rightDirectGrab.selectExited.AddListener(_ => _rightGrabRay.SetActive(true));
        }
    }
}
