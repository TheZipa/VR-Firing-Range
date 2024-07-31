using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace FiringRange.Code.Logic.Weapons
{
    public class WeaponCasingReleaser : MonoBehaviour
    {
        [SerializeField] private WeaponCase _casePrefab;
        [SerializeField] private Transform _releaseTransform;
        [SerializeField] private Transform _parentCaseTransform;

        [SerializeField] private float _caseDeleteDuration = 5f;
        [SerializeField] private float _ejectPower;

        private ObjectPool<WeaponCase> _casePool;
        
        // TODO: Реализовать констракт

        private void Awake()
        {
            _casePool = new ObjectPool<WeaponCase>(CreateCase, EnableCase, DisableCase, 
                DeleteCase, false, 30);
        }

        private void CasingRelease()
        {
            WeaponCase weaponCase = _casePool.Get();
            SetCaseTransform(weaponCase.transform);
            weaponCase.Release(_releaseTransform, _ejectPower);
            StartCoroutine(RemoveCase(weaponCase));
        }

        private void SetCaseTransform(Transform caseTransform)
        {
            caseTransform.position = _releaseTransform.position;
            caseTransform.rotation = _releaseTransform.rotation;
        }
        
        private WeaponCase CreateCase() => Instantiate(_casePrefab, _parentCaseTransform);

        private void EnableCase(WeaponCase weaponCase) => weaponCase.gameObject.SetActive(true);

        private void DisableCase(WeaponCase weaponCase) => weaponCase.gameObject.SetActive(false);

        private void DeleteCase(WeaponCase weaponCase) => Destroy(weaponCase.gameObject);

        private IEnumerator RemoveCase(WeaponCase weaponCase)
        {
            yield return new WaitForSeconds(_caseDeleteDuration);
            _casePool.Release(weaponCase);
        }
    }
}