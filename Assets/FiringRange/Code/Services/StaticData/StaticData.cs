using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Services.StaticData.StaticDataProvider;

namespace FiringRange.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public CommonConfig CommonConfig { get; private set; }
        public LocationData LocationData { get; private set; }
        public TargetConfig[] TargetsConfigs { get; private set; }

        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        public void LoadStaticData()
        {
            CommonConfig = _staticDataProvider.LoadCommonConfig();
            LocationData = _staticDataProvider.LoadLocationData();
            TargetsConfigs = _staticDataProvider.LoadTargetsConfig();
            foreach (TargetConfig targetsConfig in TargetsConfigs)
                targetsConfig.LocationBounds = new LocationBounds(LocationData.TargetSpawnLocation.Position, targetsConfig.TargetsPlaceBoxSize);
        }
    }
}