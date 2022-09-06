using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Code.Weapons
{
    public class WeaponAnimator : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable _grabInteractable;
        [SerializeField] private Animator _animator;
        private readonly int _fireHash = Animator.StringToHash("Fire");

        private void Awake() => _grabInteractable.activated.AddListener(StartShoot);

        private void OnDestroy() => _grabInteractable.activated.RemoveAllListeners();

        private void StartShoot(ActivateEventArgs args) => _animator.SetTrigger(_fireHash);
    }
}