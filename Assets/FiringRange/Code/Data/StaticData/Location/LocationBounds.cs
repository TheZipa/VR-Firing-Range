using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    public struct LocationBounds
    {
        public Vector2 XBounds;
        public Vector2 YBounds;
        public Vector2 ZBounds;

        public LocationBounds(Vector3 location, Vector3 size)
        {
            Vector3 halfSize = size / 2;
            XBounds = new Vector2(location.x + halfSize.x, location.x - halfSize.x);
            YBounds = new Vector2(location.y + halfSize.y, location.y - halfSize.y);
            ZBounds = new Vector2(location.z + halfSize.z, location.z - halfSize.z);
        }
    }
}