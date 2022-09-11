using UnityEngine;

namespace Code
{
    public class CollectableBlink : MonoBehaviour
    {
        [SerializeField] private Material _blinkMaterial;
        [SerializeField] private Material _defaultMaterial;
        private Material _currentMaterial;
    
        private void Awake() => _currentMaterial = GetComponent<Material>();

        public void SetDefault() => _currentMaterial = _defaultMaterial;

        public void SetBlink() => _currentMaterial = _blinkMaterial;
    }
}
