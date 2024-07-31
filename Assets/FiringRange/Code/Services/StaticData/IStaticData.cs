using FiringRange.Code.Data.StaticData;

namespace FiringRange.Code.Services.StaticData
{
    public interface IStaticData : IGlobalService
    {
        GameSettings GameSettings { get; }
        void LoadStaticData();
    }
}