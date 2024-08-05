using System;
using Cysharp.Threading.Tasks;
using FiringRange.Code.Logic.Common;
using FiringRange.Code.Logic.Weapons.Case;
using FiringRange.Code.Logic.Weapons.Decal;
using FiringRange.Code.Logic.Weapons.Pistol;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.Factories.PlacementFactory;
using FiringRange.Code.Services.SaveLoad;
using FiringRange.Code.Services.StaticData;
using FiringRange.Code.Services.TargetsProvider;
using FiringRange.Code.Services.Timer;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace FiringRange.Code.Services.Factories.GameFactory
{
    public class GameFactory : BaseFactory.BaseFactory, IGameFactory
    {
        private readonly IStaticData _staticData;
        private readonly ITargetsProvider _targetsProvider;
        private readonly IPlacementFactory _placementFactory;
        private readonly ISaveLoad _saveLoad;
        private readonly ITimer _timer;

        public GameFactory(IAssets assets, IEntityContainer entityContainer, ITimer timer, ITargetsProvider targetsProvider,
            IPlacementFactory placementFactory, IStaticData staticData, ISaveLoad saveLoad) : base(assets, entityContainer)
        {
            _staticData = staticData;
            _saveLoad = saveLoad;
            _timer = timer;
            _targetsProvider = targetsProvider;
            _placementFactory = placementFactory;
        }

        public async UniTask WarmUp()
        {
            await _assets.Load<GameObject>(nameof(WeaponCase));
            await _assets.Load<GameObject>(nameof(Pistol));
            await _assets.Load<GameObject>(nameof(XRPlayer.XRPlayer));
            await _assets.Load<GameObject>(nameof(BulletHoleDecal));
            await _assets.Load<GameObject>(nameof(GameStatsView));
        }

        public async UniTask<XRPlayer.XRPlayer> CreateXRPlayer() => 
            await InstantiateAsRegistered<XRPlayer.XRPlayer>(_staticData.LocationData.PlayerSpawnLocation);

        public async UniTask<Pistol> CreatePistol()
        {
            Pistol pistol = await InstantiateAsRegistered<Pistol>(_staticData.LocationData.PistolSpawnLocation);
            pistol.Construct(_entityContainer.GetEntity<XRPlayer.XRPlayer>().InteractionManager);
            pistol.Casing.Construct(CreatePool<WeaponCase>(40));
            pistol.Shooter.Construct(_targetsProvider, _entityContainer.GetEntity<DecalPlacement>());
            return pistol;
        }

        public async UniTask<FiringRangeGame> CreateFiringRangeGame()
        {
            GameStatsView gameStatsView = await InstantiateAsRegistered<GameStatsView>(_staticData.LocationData.GameStatsViewLocation);
            FiringRangeGame firingRangeGame = new FiringRangeGame(_timer, gameStatsView, await _placementFactory.CreateTargetPlacements(),
                TimeSpan.FromSeconds(_staticData.CommonConfig.FiringRangeTime));
            _entityContainer.RegisterEntity(firingRangeGame);
            return firingRangeGame;
        }

        public void CreateDecalPlacement()
        {
            DecalPlacement decalPlacement = new(CreatePool<BulletHoleDecal>(50), _staticData.CommonConfig.DecalLifeTime);
            _entityContainer.RegisterEntity(decalPlacement);
        }

        private IObjectPool<T> CreatePool<T>(int capacity) where T : MonoBehaviour => new ObjectPool<T>(
                () => Instantiate<T>().GetAwaiter().GetResult(),
                behaviour => behaviour.gameObject.SetActive(true),
                behaviour => behaviour.gameObject.SetActive(false),
                Object.Destroy, true, capacity);
    }
}