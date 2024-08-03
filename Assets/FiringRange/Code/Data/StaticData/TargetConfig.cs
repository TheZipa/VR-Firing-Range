using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FiringRange.Code.Data.StaticData
{
    public abstract class TargetConfig : ScriptableObject
    {
        public int TargetsCount = 1;
        public Vector3 TargetSize = new Vector3(1, 1, 1);
        public Vector3 TargetsPlaceBoxSize = new Vector3(12, 12, 6);
        public AssetReference TargetAsset;
        [HideInInspector] public LocationBounds LocationBounds;
    }
}