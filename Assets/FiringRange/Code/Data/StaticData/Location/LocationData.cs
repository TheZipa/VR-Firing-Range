using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "StaticData/LocationData")]
    public class LocationData : ScriptableObject
    {
        public Location PlayerSpawnLocation;
        public Location PistolSpawnLocation;
        public Location GameStatsViewLocation;
        public Location TargetSpawnLocation;
    }
}