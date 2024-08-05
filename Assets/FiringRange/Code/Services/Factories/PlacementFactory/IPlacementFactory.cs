using Cysharp.Threading.Tasks;
using FiringRange.Code.Logic.Common;
using FiringRange.Code.Logic.Common.TargetPlace;

namespace FiringRange.Code.Services.Factories.PlacementFactory
{
    public interface IPlacementFactory : IGlobalService
    {
        UniTask<TargetPlacement[]> CreateTargetPlacements();
    }
}