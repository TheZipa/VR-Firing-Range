using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "CommonConfig", menuName = "StaticData/CommonConfig")]
    public class CommonConfig : ScriptableObject
    {
        public float DecalLifeTime;
        public float FiringRangeTime;
    }
}