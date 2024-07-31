using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Services.StaticData.StaticDataProvider;

namespace FiringRange.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public GameSettings GameSettings { get; private set; }

        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        public void LoadStaticData()
        {
            GameSettings = _staticDataProvider.LoadGameConfiguration();
        }
    }
}