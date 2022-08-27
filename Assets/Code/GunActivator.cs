using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunActivator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private readonly int _fireHash = Animator.StringToHash("Fire");
    private XRGrabInteractable _grabInteractable;

    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _grabInteractable.activated.AddListener(StartShoot);
    }

    private void OnDestroy() => _grabInteractable.activated.RemoveAllListeners();

    private void StartShoot(ActivateEventArgs args) => _animator.SetTrigger(_fireHash);
}
