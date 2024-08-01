using FiringRange.Code.Data.StaticData;
using UnityEngine;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string FiringRangeConfigPath = "StaticData/FiringRangeConfig";
        private const string LocationDataPath = "StaticData/LocationData";

        public FiringRangeConfig LoadFiringRangeConfig() => Resources.Load<FiringRangeConfig>(FiringRangeConfigPath);

        public LocationData LoadLocationData() => Resources.Load<LocationData>(LocationDataPath);
    }
}