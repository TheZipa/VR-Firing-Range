using FiringRange.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.Pool;

namespace FiringRange.Code.Logic.Weapons.Decal
{
    public class DecalPlacement : IFactoryEntity
    {
        private readonly IObjectPool<BulletHoleDecal> _decalPool;
        private readonly float _decalRemoveDuration;

        public DecalPlacement(IObjectPool<BulletHoleDecal> decalPool, float decalRemoveDuration)
        {
            _decalRemoveDuration = decalRemoveDuration;
            _decalPool = decalPool;
        }
        
        public void SpawnDecalAtPoint(Vector3 point, Vector3 normal, Transform parent)
        {
            BulletHoleDecal bulletHoleDecal = _decalPool.Get();
            bulletHoleDecal.transform.position = point;
            bulletHoleDecal.transform.forward = normal;
            bulletHoleDecal.transform.SetParent(parent);
            bulletHoleDecal.Enable(_decalPool.Release, _decalRemoveDuration);
        }
    }
}