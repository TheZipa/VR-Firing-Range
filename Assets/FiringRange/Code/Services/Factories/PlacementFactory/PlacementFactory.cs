using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Logic.Common.TargetPlace;
using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.StaticData.StaticDataProvider;
using FiringRange.Code.Services.TargetsProvider;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace FiringRange.Code.Services.Factories.PlacementFactory
{
    public class PlacementFactory : BaseFactory.BaseFactory, IPlacementFactory
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ITargetsProvider _targetsProvider;

        public PlacementFactory(IAssets assets, IEntityContainer entityContainer, 
            IStaticDataProvider staticDataProvider, ITargetsProvider targetsProvider) 
            : base(assets, entityContainer)
        {
            _staticDataProvider = staticDataProvider;
            _targetsProvider = targetsProvider;
        }

        public async UniTask<TargetPlacement[]> CreateTargetPlacements()
        {
            List<TargetPlacement> placements = new(2) { await CreateRandomTargetPlacement() };
            return placements.ToArray();
        }

        private async UniTask<RandomTargetPlacement> CreateRandomTargetPlacement()
        {
            RandomTargetConfig randomTargetConfig = _staticDataProvider.LoadTargetConfig<RandomTargetConfig>();
            Target[] targets = await CreateTargets(randomTargetConfig.TargetAsset,
                randomTargetConfig.TargetSize, randomTargetConfig.TargetsCount);
            RandomTargetPlacement randomTargetPlacement = new RandomTargetPlacement(targets, randomTargetConfig);
            return randomTargetPlacement;
        }

        private async UniTask<Target[]> CreateTargets(AssetReference targetReference, Vector3 size, int count)
        {
            await _assets.Load<GameObject>(targetReference);
            Target[] targets = new Target[count];
            for (int i = 0; i < count; i++) 
                targets[i] = await CreateTarget(targetReference, size);
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