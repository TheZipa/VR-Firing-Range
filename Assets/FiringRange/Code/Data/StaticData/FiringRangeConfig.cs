using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "FiringRangeConfig", menuName = "StaticData/FiringRangeConfig")]
    public class FiringRangeConfig : ScriptableObject
    {
        public float DecalLifeTime;
    }
}