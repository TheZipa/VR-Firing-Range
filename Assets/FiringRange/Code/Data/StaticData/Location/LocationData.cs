using UnityEngine;

namespace FiringRange.Code.Data.StaticData.Location
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "StaticData/LocationData")]
    public class LocationData : ScriptableObject
    {
        [Header("Common")]
        public Location PlayerSpawnLocation;
        public Location PistolSpawnLocation;
        public Location GameStatsViewLocation;
        public Location TargetSpawnLocation;
        [Header("Interactables")] 
        public Location StartButtonLocation;
    }
}