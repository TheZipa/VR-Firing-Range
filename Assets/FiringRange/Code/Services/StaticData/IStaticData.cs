using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Data.StaticData.Location;

namespace FiringRange.Code.Services.StaticData
{
    public interface IStaticData : IGlobalService
    {
        CommonConfig CommonConfig { get; }
        LocationData LocationData { get; }
        void LoadStaticData();
    }
}