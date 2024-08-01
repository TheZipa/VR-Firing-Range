using Cysharp.Threading.Tasks;
using FiringRange.Code.Logic.Weapons.Pistol;
using FiringRange.Code.Services.Factories.BaseFactory;
using FiringRange.Code.XRInput;

namespace FiringRange.Code.Services.Factories.GameFactory
{
    public interface IGameFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
        UniTask<XRPlayer> CreateXRPlayer();
        UniTask<Pistol> CreatePistol();
        void CreateDecalPlacement();
    }
}