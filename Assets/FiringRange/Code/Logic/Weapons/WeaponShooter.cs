using System.Collections;
using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Logic.Weapons.Muzzle;
using UnityEngine;
using UnityEngine.Pool;

namespace FiringRange.Code.Logic.Weapons
{
    public class WeaponShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shotTransform;
        [SerializeField] private Transform _parentDecalTransform;
        [SerializeField] private GameObject _hitDecal;
        [SerializeField] private WeaponMuzzleFlash _muzzleFlash;

        [SerializeField] private float _hitForce = 2.5f;
        [SerializeField] private float _decalRemoveDuration = 10f;
        [SerializeField] private float _maxHitDistance = 125f;

        private ObjectPool<GameObject> _decalPool;

        // TODO: Реализовать констракт
        
        private void Awake()
        {
            _decalPool = new ObjectPool<GameObject>(CreateDecal, EnableDecal, 
                DisableDecal, DeleteDecal, false, 30);
        }

        private void OnDestroy() => _decalPool.Dispose();

        private void Shoot()
        {
            Ray ray = new Ray(_shotTransform.position, _shotTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxHitDistance))
            {
                SpawnDecalAtPoint(hit.point, hit.normal, hit.transform);
                hit.rigidbody?.AddForce(hit.normal * _hitForce * -1, ForceMode.Impulse);
                if(hit.transform.TryGetComponent<Target>(out Target target)) target.TakeHit(); // TODO: получить таргет через сервис
            }

            _muzzleFlash.Show();
        }

        private void SpawnDecalAtPoint(Vector3 point, Vector3 normal, Transform parent)
        {
            GameObject decal = _decalPool.Get();
            decal.transform.position = point;
            decal.transform.forward = normal;
            decal.transform.SetParent(parent);
            StartCoroutine(RemoveDecal(decal));
        }

        private GameObject CreateDecal() => Instantiate(_hitDecal, _parentDecalTransform);

        private void EnableDecal(GameObject decal) => decal.SetActive(true);

        private void DisableDecal(GameObject decal) => decal.SetActive(false);

        private void DeleteDecal(GameObject decal) => Destroy(decal);

        private IEnumerator RemoveDecal(GameObject decal)
        {
            yield return new WaitForSeconds(_decalRemoveDuration);
            _decalPool.Release(decal);
        }
    }
}