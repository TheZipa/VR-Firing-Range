using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Services.StaticData.StaticDataProvider;

namespace FiringRange.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public FiringRangeConfig FiringRangeConfig { get; private set; }
        public LocationData LocationData { get; private set; }

        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        public void LoadStaticData()
        {
            FiringRangeConfig = _staticDataProvider.LoadFiringRangeConfig();
            LocationData = _staticDataProvider.LoadLocationData();
        }
    }
}