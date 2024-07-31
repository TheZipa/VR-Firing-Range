using DG.Tweening;
using UnityEngine;

namespace FiringRange.Code.Logic.Hit
{
    public class ColorHit : Hit
    {
        [SerializeField] private MeshRenderer _view;
        [SerializeField] private Color _damageColor;
        [SerializeField] private float _fadeDuration;
        
        private Color _initialColor;
        private Tween _damageTween;

        private void Awake()
        {
            _initialColor = _view.material.color;
        }

        public override void TakeHit()
        {
            _damageTween?.Kill();
            _view.material.color = _damageColor;
            _damageTween = _view.material.DOColor(_initialColor, _fadeDuration);
        }
    }
}