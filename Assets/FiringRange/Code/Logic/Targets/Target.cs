using UnityEngine;

namespace FiringRange.Code.Logic.Targets
{
    public abstract class Target : MonoBehaviour
    {
        [SerializeField] protected AudioSource _hitAudio;
        [SerializeField] protected Hit.Hit _hitBehaviour;

        private void Start() => Enable();

        public abstract void Enable();

        public abstract void Disable();

        public virtual void TakeHit()
        {
            _hitAudio.PlayOneShot(_hitAudio.clip);
            _hitBehaviour.TakeHit();
        }
    }
}