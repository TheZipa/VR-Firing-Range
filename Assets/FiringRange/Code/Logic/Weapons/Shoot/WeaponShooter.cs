using FiringRange.Code.Logic.Weapons.Muzzle;
using UnityEngine;

namespace FiringRange.Code.Logic.Weapons
{
    public abstract class WeaponShooter : MonoBehaviour
    {
        [SerializeField] protected Transform _shootTransform;
        [SerializeField] protected WeaponMuzzleFlash _muzzleFlash;

        protected DecalPlacement _decalPlacement;

        public void Construct(DecalPlacement decalPlacement) => _decalPlacement = decalPlacement;

        public abstract void Shoot();
    }
}