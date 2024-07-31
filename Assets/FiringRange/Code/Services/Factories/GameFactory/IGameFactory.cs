using Cysharp.Threading.Tasks;
using FiringRange.Code.Services.Factories.BaseFactory;

namespace FiringRange.Code.Services.Factories.GameFactory
{
    public interface IGameFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
    }
}