using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Code.Weapons
{
    public class WeaponShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shotTransform;
        [SerializeField] private Transform _parentDecalTransform;
        [SerializeField] private GameObject _hitDecal;
        [SerializeField] private WeaponMuzzleFlash _muzzleFlash;
        
        [SerializeField] private float _decalRemoveDuration = 10f;
        [SerializeField] private float _maxHitDistance = 125f;

        private ObjectPool<GameObject> _decalPool;

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
                SpawnDecalAtPoint(hit.point, hit.normal);
            
            _muzzleFlash.Show();
        }

        private void SpawnDecalAtPoint(Vector3 point, Vector3 normal)
        {
            GameObject decal = _decalPool.Get();
            decal.transform.position = point;
            decal.transform.forward = normal;
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