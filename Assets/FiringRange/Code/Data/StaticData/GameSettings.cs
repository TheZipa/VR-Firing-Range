using UnityEngine;

namespace FiringRange.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "GameGameSettings", menuName = "StaticData/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public int StartBalance;
    }
}