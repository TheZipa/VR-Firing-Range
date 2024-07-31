using Cysharp.Threading.Tasks;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.SaveLoad;
using FiringRange.Code.Services.StaticData;

namespace FiringRange.Code.Services.Factories.GameFactory
{
    public class GameFactory : BaseFactory.BaseFactory, IGameFactory
    {
        private readonly IStaticData _staticData;
        private readonly ISaveLoad _saveLoad;

        public GameFactory(IAssets assets, IEntityContainer entityContainer, 
            IStaticData staticData, ISaveLoad saveLoad) : base(assets, entityContainer)
        {
            _staticData = staticData;
            _saveLoad = saveLoad;
        }

        public async UniTask WarmUp()
        {
            
        }
    }
}