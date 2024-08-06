using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "GridTargetConfig", menuName = "StaticData/Targets/GridTargetConfig")]
    public class GridTargetConfig : TargetConfig
    {
        public int GridSize;
        public float GridOffset;
        public float DistanceOffset;
    }
}