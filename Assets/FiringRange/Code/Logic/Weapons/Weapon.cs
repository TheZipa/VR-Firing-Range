using FiringRange.Code.Logic.Weapons.Case;
using FiringRange.Code.Logic.Weapons.Shoot;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.Logic.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponShooter Shooter => _weaponShooter;
        public WeaponCasingReleaser Casing => _weaponCasing;
        public WeaponAnimator Animator => _weaponAnimator;
        
        [SerializeField] protected XRGrabInteractable _grabInteractable;
        [SerializeField] protected WeaponShooter _weaponShooter;
        [SerializeField] protected WeaponAnimator _weaponAnimator;
        [SerializeField] protected WeaponCasingReleaser _weaponCasing;
        [SerializeField] protected Rigidbody _rigidbody;

        public void Construct(XRInteractionManager interactionManager)
        {
            _grabInteractable.interactionManager = interactionManager;
            _grabInteractable.selectEntered.AddListener(Grab);
            _grabInteractable.selectExited.AddListener(Drop);
        }

        private void Grab(SelectEnterEventArgs arg0)
        {
            _rigidbody.isKinematic = true;
            Shooter.Enable();
        }

        private void Drop(SelectExitEventArgs arg0)
        {
            _rigidbody.isKinematic = false;
            Shooter.Disable();
        }
    }
}