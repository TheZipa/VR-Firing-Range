using UnityEngine;

namespace FiringRange.Code.Logic.Weapons.Case
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponCase : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Release(Transform releaseTransform, float ejectPower) =>
            _rigidbody.velocity += (releaseTransform.right * Random.Range(0.7f, 1f)
                                    + releaseTransform.up * Random.Range(0.7f, 1f)) * ejectPower;
    }
}