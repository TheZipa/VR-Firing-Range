using UnityEngine;

namespace FiringRange.Code.Logic.Weapons
{
    public class WeaponAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private readonly int _fireHash = Animator.StringToHash("Fire");

        public void StartShoot() => _animator.SetTrigger(_fireHash);
    }
}