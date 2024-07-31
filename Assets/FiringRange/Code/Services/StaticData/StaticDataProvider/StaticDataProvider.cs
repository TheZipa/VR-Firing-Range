using FiringRange.Code.Data.StaticData;
using UnityEngine;

namespace FiringRange.Code.Services.StaticData.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string GameConfigurationPath = "StaticData/GameConfiguration";

        public GameSettings LoadGameConfiguration() => Resources.Load<GameSettings>(GameConfigurationPath);
    }
}