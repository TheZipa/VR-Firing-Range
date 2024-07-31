using FiringRange.Code.Data.Progress;

namespace FiringRange.Code.Services.SaveLoad
{
    public interface ISaveLoad : IGlobalService
    {
        UserProgress Progress { get; }
        void Load();
    }
}