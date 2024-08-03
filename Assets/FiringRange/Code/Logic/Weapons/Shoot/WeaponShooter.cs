using FiringRange.Code.Logic.Weapons.Decal;
using FiringRange.Code.Logic.Weapons.Muzzle;
using FiringRange.Code.Services.TargetsProvider;
using UnityEngine;

namespace FiringRange.Code.Logic.Weapons.Shoot
{
    public abstract class WeaponShooter : MonoBehaviour
    {
        [SerializeField] protected Transform _shootTransform;
        [SerializeField] protected WeaponMuzzleFlash _muzzleFlash;
        [SerializeField] protected AudioSource _shootAudio;

        protected DecalPlacement _decalPlacement;
        protected ITargetsProvider _targetsProvider;

        public void Construct(ITargetsProvider targetsProvider, DecalPlacement decalPlacement)
        {
            _targetsProvider = targetsProvider;
            _decalPlacement = decalPlacement;
        }

        public virtual void Shoot() => _shootAudio.PlayOneShot(_shootAudio.clip);

        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }
    }
}