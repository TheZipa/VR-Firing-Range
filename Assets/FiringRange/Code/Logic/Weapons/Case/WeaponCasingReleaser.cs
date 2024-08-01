using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace FiringRange.Code.Logic.Weapons.Case
{
    public class WeaponCasingReleaser : MonoBehaviour
    {
        [SerializeField] private Transform _releaseTransform;
        [SerializeField] private float _caseDeleteDuration = 5f;
        [SerializeField] private float _ejectPower;

        private IObjectPool<WeaponCase> _casePool;

        public void Construct(IObjectPool<WeaponCase> casePool) => _casePool = casePool;

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

        private IEnumerator RemoveCase(WeaponCase weaponCase)
        {
            yield return new WaitForSeconds(_caseDeleteDuration);
            _casePool.Release(weaponCase);
        }
    }
}