using FiringRange.Code.Logic.Weapons.Case;
using FiringRange.Code.Logic.Weapons.Shoot;
using FiringRange.Code.XRPlayer;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.Logic.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponShooter Shooter => _weaponShooter;
        public WeaponCasingReleaser Casing => _weaponCasing;
        public WeaponAnimator Animator => _weaponAnimator;
        
        [SerializeField] protected XRGrabInteractableTwoAttach _grabInteractable;
        [SerializeField] protected WeaponShooter _weaponShooter;
        [SerializeField] protected WeaponAnimator _weaponAnimator;
        [SerializeField] protected WeaponCasingReleaser _weaponCasing;

        public void Construct(XRInteractionManager interactionManager)
        {
            _grabInteractable.interactionManager = interactionManager;
            _grabInteractable.OnGrab += Shooter.Enable;
            _grabInteractable.OnDrop += Shooter.Disable;
        }
    }
}