using Cysharp.Threading.Tasks;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.StaticData;
using FiringRange.Code.XRPlayer;
using UnityEngine;

namespace FiringRange.Code.Services.Factories.XRInteractionFactory
{
    public class XRInteractionFactory : BaseFactory.BaseFactory, IXRInteractionFactory
    {
        private readonly IStaticData _staticData;

        public XRInteractionFactory(IAssets assets, IEntityContainer entityContainer, IStaticData staticData) : base(assets, entityContainer)
        {
            _staticData = staticData;
        }

        public async UniTask WarmUp()
        {
            await _assets.Load<GameObject>(nameof(XRButton));
        }

        public async UniTask<XRButton> CreateStartButton()
        {
            XRButton xrButton = await InstantiateAsRegistered<XRButton>(_staticData.LocationData.StartButtonLocation);
            xrButton.Construct(_entityContainer.GetEntity<XRPlayer.XRPlayer>().InteractionManager);
            return xrButton;
        }
    }
}