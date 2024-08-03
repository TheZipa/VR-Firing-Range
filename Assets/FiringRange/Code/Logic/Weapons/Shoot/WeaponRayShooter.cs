using UnityEngine;

namespace FiringRange.Code.Logic.Weapons.Shoot
{
    public class WeaponRayShooter : WeaponShooter
    {
        [SerializeField] private LineRenderer _line;
        [SerializeField] private float _maxHitDistance = 125f;
        [SerializeField] private float _hitForce = 2.5f;
        
        public override void Shoot()
        {
            base.Shoot();
            Ray ray = new Ray(_shootTransform.position, _shootTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxHitDistance))
            {
                _decalPlacement.SpawnDecalAtPoint(hit.point, hit.normal, hit.transform);
                hit.rigidbody?.AddForce(hit.normal * _hitForce * -1, ForceMode.Impulse);
                _targetsProvider.GetTarget(hit.transform)?.TakeHit();
            }

            _muzzleFlash.Show();
        }

        public override void Enable()
        {
            _line.enabled = true;
        }

        public override void Disable()
        {
            _line.enabled = false;
        }

        private void Update()
        {
            _line.SetPosition(0, _shootTransform.position);
            _line.SetPosition(1, _shootTransform.position + _shootTransform.forward * _maxHitDistance);
        }
    }
}