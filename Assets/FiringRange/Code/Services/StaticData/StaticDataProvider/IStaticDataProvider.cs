using FiringRange.Code.Data.StaticData;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public interface IStaticDataProvider : IGlobalService
    {
        FiringRangeConfig LoadFiringRangeConfig();
        LocationData LoadLocationData();
    }
}