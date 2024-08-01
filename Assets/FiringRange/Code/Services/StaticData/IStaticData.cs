using FiringRange.Code.Data.StaticData;

namespace FiringRange.Code.Services.StaticData
{
    public interface IStaticData : IGlobalService
    {
        FiringRangeConfig FiringRangeConfig { get; }
        LocationData LocationData { get; }
        void LoadStaticData();
    }
}