using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Logic.Common.TargetPlace;
using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.StaticData;
using FiringRange.Code.Services.StaticData.StaticDataProvider;
using FiringRange.Code.Services.TargetsProvider;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace FiringRange.Code.Services.Factories.PlacementFactory
{
    public class PlacementFactory : BaseFactory.BaseFactory, IPlacementFactory
    {
        private readonly IStaticData _staticData;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ITargetsProvider _targetsProvider;

        public PlacementFactory(IAssets assets, IEntityContainer entityContainer, IStaticData staticData,
            IStaticDataProvider staticDataProvider, ITargetsProvider targetsProvider) 
            : base(assets, entityContainer)
        {
            _staticData = staticData;
            _staticDataProvider = staticDataProvider;
            _targetsProvider = targetsProvider;
        }

        public async UniTask<TargetPlacement[]> CreateTargetPlacements()
        {
            List<TargetPlacement> placements = new(2)
            {
                await CreateRandomTargetPlacement(),
                await CreateGridTargetPlacement()
            };
            return placements.ToArray();
        }

        private async UniTask<RandomTargetPlacement> CreateRandomTargetPlacement()
        {
            RandomTargetConfig randomTargetConfig = _staticDataProvider.LoadTargetConfig<RandomTargetConfig>();
            RandomTargetPlacement randomTargetPlacement = new RandomTargetPlacement(await CreateTargets(randomTargetConfig), randomTargetConfig);
            return randomTargetPlacement;
        }

        private async UniTask<GridTargetPlacement> CreateGridTargetPlacement()
        {
            GridTargetConfig gridTargetConfig = _staticDataProvider.LoadTargetConfig<GridTargetConfig>();
            GridTargetPlacement gridTargetPlacement = new GridTargetPlacement(await CreateTargets(gridTargetConfig),
                gridTargetConfig, _staticData.LocationData.TargetSpawnLocation.Position);
            return gridTargetPlacement;
        }

        private async UniTask<Target[]> CreateTargets(TargetConfig targetConfig)
        {
            await _assets.Load<GameObject>(targetConfig.TargetAsset);
            Target[] targets = new Target[targetConfig.TargetsCount];
            for (int i = 0; i < targetConfig.TargetsCount; i++) 
                targets[i] = await CreateTarget(targetConfig.TargetAsset, targetConfig.TargetSize);
            return targets;
        }

        private async UniTask<Target> CreateTarget(AssetReference targetReference, Vector3 size)
        {
            Target target = await Instantiate<Target>(targetReference);
            target.transform.localScale = size;
            target.Disable();
            _targetsProvider.AddTarget(target);
            return target;
        }
    }
}