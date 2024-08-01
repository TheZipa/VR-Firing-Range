using System;
using System.Collections;
using UnityEngine;

namespace FiringRange.Code.Logic.Weapons.Decal
{
    public class BulletHoleDecal : MonoBehaviour
    {
        public void Enable(Action<BulletHoleDecal> onLifeTimeEnd, float removeDuration) =>
            StartCoroutine(RemoveDecal(onLifeTimeEnd, removeDuration));

        private IEnumerator RemoveDecal(Action<BulletHoleDecal> onLifeTimeEnd, float removeDuration)
        {
            yield return new WaitForSeconds(removeDuration);
            onLifeTimeEnd.Invoke(this);
        }
    }
}