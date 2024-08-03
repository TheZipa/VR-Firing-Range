using DG.Tweening;
using UnityEngine;

namespace FiringRange.Code.Logic.Targets
{
    public class StrafeTarget : Target
    {
        [SerializeField] private Vector3 _strafePosition;
        private Tween _strafeTween;
        
        public override void Enable()
        {
            base.Enable();
            Vector3 initialPosition = transform.position;
            _strafeTween = DOTween.Sequence()
                .Append(transform.DOMove(_strafePosition, 5f).SetEase(Ease.Linear))
                .Append(transform.DOMove(initialPosition, 5f).SetEase(Ease.Linear))
                .SetLoops(-1);
        }

        public override void Disable()
        {
            base.Disable();
            _strafeTween?.Kill();
            _strafeTween = null;
        }
    }
}