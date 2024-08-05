using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Data.StaticData.Location;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public interface IStaticDataProvider : IGlobalService
    {
        CommonConfig LoadCommonConfig();
        LocationData LoadLocationData();
        T LoadTargetConfig<T>() where T : TargetConfig;
        TargetConfig[] LoadAllTargetConfigs();
    }
}