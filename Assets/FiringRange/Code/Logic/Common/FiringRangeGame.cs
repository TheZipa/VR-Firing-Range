using System;
using FiringRange.Code.Services.EntityContainer;
using FiringRange.Code.Services.Timer;
using UniRx;

namespace FiringRange.Code.Logic.Common
{
    public class FiringRangeGame : IFactoryEntity
    {
        public event Action OnEnd;
        public readonly IntReactiveProperty Points = new(0);
        
        private readonly ITimer _timer;
        private readonly TargetPlacement[] _placements;
        private readonly TimeSpan _gameTime;
        private readonly IDisposable _disposable;
        private int _placementIndex = 0;

        public FiringRangeGame(ITimer timer, GameStatsView gameStatsView, TargetPlacement[] placements, TimeSpan gameTime)
        {
            _gameTime = gameTime;
            _timer = timer;
            _placements = placements;
            _timer.OnTimerComplete += Finish;
            _timer.OnTimerUpdate += gameStatsView.UpdateTimeText;
            _disposable = Points.Subscribe(gameStatsView.UpdatePointsText);
        }

        public void SwitchTargetPlacement(int placementIndex) => _placementIndex = placementIndex;

        public void Start()
        {
            Points.Value = 0;
            CurrentPlacement().PlaceAll();
            _timer.Start(_gameTime);
        }

        private void Finish()
        {
            CurrentPlacement().Disable();
            OnEnd?.Invoke();
        }

        private TargetPlacement CurrentPlacement() => _placements[_placementIndex];

        ~FiringRangeGame() => _disposable.Dispose();
    }
}