using FiringRange.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FiringRange.Code.XRInput
{
    public class XRPlayer : MonoBehaviour, IFactoryEntity
    {
        public XRInteractionManager InteractionManager => _interactionManager;
        
        [SerializeField] private XRInteractionManager _interactionManager;
    }
}