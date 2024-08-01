using System;
using FiringRange.Code.Services.EntityContainer;
using TMPro;
using UnityEngine;

namespace FiringRange.Code.Logic.Common
{
    public class GameStatsView : MonoBehaviour, IFactoryEntity
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private TMP_Text _pointsText;
        private const string TimeFormat = @"mm\:ss";

        public void UpdateTimeText(TimeSpan time) => _timerText.text = time.ToString(TimeFormat);

        public void UpdatePointsText(int points) => _pointsText.text = points.ToString();
    }
}