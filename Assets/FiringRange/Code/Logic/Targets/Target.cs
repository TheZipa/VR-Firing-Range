using System;
using UnityEngine;

namespace FiringRange.Code.Logic.Targets
{
    public abstract class Target : MonoBehaviour
    {
        public event Action<Target> OnHit;
        [SerializeField] protected AudioSource _hitAudio;
        [SerializeField] protected Hit.Hit _hitBehaviour;

        public virtual void Enable() => gameObject.SetActive(true);

        public virtual void Disable() => gameObject.SetActive(false);

        public virtual void TakeHit()
        {
            _hitAudio.PlayOneShot(_hitAudio.clip);
            _hitBehaviour.TakeHit();
            OnHit?.Invoke(this);
        }
    }
}