using FiringRange.Code.Data.StaticData;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public interface IStaticDataProvider : IGlobalService
    {
        CommonConfig LoadCommonConfig();
        LocationData LoadLocationData();
        TargetConfig[] LoadTargetsConfig();
    }
}