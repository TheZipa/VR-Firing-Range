using FiringRange.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRPlayer
{
    public class XRButton : MonoBehaviour, IFactoryEntity
    {
        public UnityEvent OnClick;
        [Header("Visuals")]
        [SerializeField] private Material _pressedMaterial;
        [SerializeField] private Material _idleMaterial;
        [SerializeField] private Transform _visualTarget;
        [SerializeField] private MeshRenderer _interactableRenderer;
        
        [Space(12), Header("Settings")]
        [SerializeField] private XRBaseInteractable _interactable;
        [SerializeField] private Vector3 _localAxis;
        [SerializeField] private float _resetSpeed = 5;
        [SerializeField] private float _followAngleThreshold = 45;
        [SerializeField] private float _pressDelay;

        private Transform _pokeAttachTransform;
        private Vector3 _initialLocalPosition;
        private Vector3 _offset;
        private float _pressTime;
        private bool _isFreeze;
        private bool _isFollowing;
        
        public void Construct(XRInteractionManager interactionManager)
        {
            _initialLocalPosition = _visualTarget.localPosition;
            _interactable.interactionManager = interactionManager;
            _interactable.hoverEntered.AddListener(Follow);
            _interactable.hoverExited.AddListener(Reset);
            _interactable.selectEntered.AddListener(Freeze);
        }

        private void Follow(BaseInteractionEventArgs hover)
        {
            if (hover.interactorObject is not XRPokeInteractor) return;
            SetFollowData(hover);

            float pokeAngle = Vector3.Angle(_offset, _visualTarget.TransformDirection(_localAxis));
            if (pokeAngle < _followAngleThreshold) return;
            _isFollowing = false;
            _isFreeze = true;
        }

        private void SetFollowData(BaseInteractionEventArgs hover)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            _isFollowing = true;
            _pokeAttachTransform = interactor.attachTransform;
            _offset = _visualTarget.position - _pokeAttachTransform.position;
        }

        private void Reset(BaseInteractionEventArgs hover)
        {
            if (hover.interactorObject is not XRPokeInteractor) return;
            _interactableRenderer.material = _idleMaterial;
            _isFollowing = false;
            _isFreeze = false;
        }

        private void Freeze(BaseInteractionEventArgs hover)
        {
            if (hover.interactorObject is not XRPokeInteractor || Time.time - _pressTime <= _pressDelay) return;
            _interactableRenderer.material = _pressedMaterial;
            _pressTime = Time.time;
            _isFreeze = true;
            OnClick.Invoke();
        }
        
        private void Update()
        {
            if (_isFreeze) return;
            if (_isFollowing) UpdateVisualFollow();
            else UpdateVisualToInitial();
        }

        private void UpdateVisualToInitial() =>
            _visualTarget.localPosition = Vector3.Lerp(_visualTarget.localPosition, _initialLocalPosition,
                Time.deltaTime * _resetSpeed);

        private void UpdateVisualFollow()
        {
            Vector3 localTargetPosition = _visualTarget.InverseTransformPoint(_pokeAttachTransform.position + _offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, _localAxis);
            _visualTarget.position = _visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
    }
}