using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Data.StaticData.Location;
using UnityEngine;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string TargetConfigsPath = "StaticData/Targets";
        private const string CommonConfigPath = "StaticData/CommonConfig";
        private const string LocationDataPath = "StaticData/LocationData";

        public CommonConfig LoadCommonConfig() => Resources.Load<CommonConfig>(CommonConfigPath);

        public LocationData LoadLocationData() => Resources.Load<LocationData>(LocationDataPath);

        public T LoadTargetConfig<T>() where T : TargetConfig
        {
            string configPath = TargetConfigsPath + '/' + typeof(T).Name;
            return Resources.Load<T>(configPath);
        }

        public TargetConfig[] LoadAllTargetConfigs() => Resources.LoadAll<TargetConfig>(TargetConfigsPath);
    }
}