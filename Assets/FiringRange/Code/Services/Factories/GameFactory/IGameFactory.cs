using Cysharp.Threading.Tasks;
using FiringRange.Code.Logic.Common;
using FiringRange.Code.Logic.Weapons.Pistol;
using FiringRange.Code.Services.Factories.BaseFactory;

namespace FiringRange.Code.Services.Factories.GameFactory
{
    public interface IGameFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
        UniTask<XRPlayer.XRPlayer> CreateXRPlayer();
        UniTask<Pistol> CreatePistol();
        void CreateDecalPlacement();
        UniTask<FiringRangeGame> CreateFiringRangeGame();
    }
}