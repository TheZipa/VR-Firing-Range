using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Data.StaticData.Location;
using FiringRange.Code.Services.StaticData.StaticDataProvider;
using UnityEditor;

namespace FiringRange.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public CommonConfig CommonConfig { get; private set; }
        public LocationData LocationData { get; private set; }

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
            foreach (TargetConfig targetsConfig in _staticDataProvider.LoadAllTargetConfigs())
            {
                targetsConfig.LocationBounds = new LocationBounds(LocationData.TargetSpawnLocation.Position, targetsConfig.TargetsPlaceBoxSize);
                EditorUtility.SetDirty(targetsConfig);
            }
        }
    }
}