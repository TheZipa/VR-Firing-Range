using UnityEngine;

namespace FiringRange.Code.Logic.Targets
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected Hit.Hit _hitBehaviour;

        private void Start() // Я дебажу нормально не пиздеть
        {
            Enable();
        }

        public abstract void Enable();

        public abstract void Disable();

        public virtual void TakeHit() => _hitBehaviour.TakeHit();
    }
}