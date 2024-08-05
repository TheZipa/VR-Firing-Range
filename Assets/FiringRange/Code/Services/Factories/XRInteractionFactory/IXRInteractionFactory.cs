using Cysharp.Threading.Tasks;
using FiringRange.Code.XRPlayer;

namespace FiringRange.Code.Services.Factories.XRInteractionFactory
{
    public interface IXRInteractionFactory : IGlobalService
    {
        UniTask WarmUp();
        UniTask<XRButton> CreateStartButton();
    }
}