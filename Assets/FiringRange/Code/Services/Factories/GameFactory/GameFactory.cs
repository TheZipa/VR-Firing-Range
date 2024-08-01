using Cysharp.Threading.Tasks;
using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Logic.Weapons;
using FiringRange.Code.Logic.Weapons.Pistol;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.SaveLoad;
using FiringRange.Code.Services.StaticData;
using FiringRange.Code.XRInput;
using UnityEngine;
using UnityEngine.Pool;

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
            await _assets.Load<GameObject>(nameof(WeaponCase));
            await _assets.Load<GameObject>(nameof(Pistol));
            //await _assets.Load<GameObject>(nameof(StrafeTarget));
            await _assets.Load<GameObject>(nameof(XRPlayer));
            await _assets.Load<GameObject>(nameof(BulletHoleDecal));
        }

        public async UniTask<XRPlayer> CreateXRPlayer() => 
            await InstantiateAsRegistered<XRPlayer>(_staticData.LocationData.PlayerSpawnLocation);

        public async UniTask<Pistol> CreatePistol()
        {
            Pistol pistol = await InstantiateAsRegistered<Pistol>(_staticData.LocationData.PistolSpawnLocation);
            pistol.Construct(_entityContainer.GetEntity<XRPlayer>().InteractionManager);
            pistol.Casing.Construct(CreatePool<WeaponCase>(40));
            pistol.Shooter.Construct(_entityContainer.GetEntity<DecalPlacement>());
            return pistol;
        }

        public void CreateDecalPlacement()
        {
            DecalPlacement decalPlacement = new(CreatePool<BulletHoleDecal>(50), _staticData.FiringRangeConfig.DecalLifeTime);
            _entityContainer.RegisterEntity(decalPlacement);
        }

        private IObjectPool<T> CreatePool<T>(int capacity) where T : MonoBehaviour => new ObjectPool<T>(
                () => Instantiate<T>().GetAwaiter().GetResult(),
                decal => decal.gameObject.SetActive(true),
                decal => decal.gameObject.SetActive(false),
                Object.Destroy, true, capacity);
    }
}