using FiringRange.Code.Logic.Targets;
using UnityEngine;

namespace FiringRange.Code.Logic.Weapons
{
    public class WeaponRayShooter : WeaponShooter
    {
        [SerializeField] private float _maxHitDistance = 125f;
        [SerializeField] private float _hitForce = 2.5f;
        
        public override void Shoot()
        {
            Ray ray = new Ray(_shootTransform.position, _shootTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxHitDistance))
            {
                _decalPlacement.SpawnDecalAtPoint(hit.point, hit.normal, hit.transform);
                hit.rigidbody?.AddForce(hit.normal * _hitForce * -1, ForceMode.Impulse);
                if(hit.transform.TryGetComponent<Target>(out Target target)) target.TakeHit(); // TODO: получить таргет через сервис
            }

            _muzzleFlash.Show();
        }
    }
}