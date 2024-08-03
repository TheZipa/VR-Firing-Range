using FiringRange.Code.Data.StaticData;

namespace FiringRange.Code.Services.StaticData
{
    public interface IStaticData : IGlobalService
    {
        CommonConfig CommonConfig { get; }
        LocationData LocationData { get; }
        TargetConfig[] TargetsConfigs { get; }
        void LoadStaticData();
    }
}